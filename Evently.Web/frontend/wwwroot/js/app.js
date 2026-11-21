(() => {
  "use strict";
  const DATA = window.EventlyDemo;
  const KEYS = {
    favorites: "evently-favorites",
    bookings: "evently-bookings",
    last: "evently-last-booking",
    checkout: "evently-checkout",
    profile: "evently-profile",
    custom: "evently-custom-events",
    drafts: "evently-event-drafts",
    moderation: "evently-moderation",
    notifications: "evently-notifications",
    overrides: "evently-event-overrides",
    removed: "evently-removed-events",
    organizerSettings: "evently-organizer-settings",
    organizerSuspension: "evently-organizer-suspension",
  };
  const $ = (selector, root = document) => root.querySelector(selector);
  const $$ = (selector, root = document) =>
    Array.from(root.querySelectorAll(selector));
  const read = (key, fallback) => {
    try {
      const value = localStorage.getItem(key);
      return value ? JSON.parse(value) : fallback;
    } catch {
      return fallback;
    }
  };
  const save = (key, value) => {
    try {
      localStorage.setItem(key, JSON.stringify(value));
      return true;
    } catch {
      toast(
        "This browser could not save the demo change. Try removing a large image or resetting the demo.",
        "error",
      );
      return false;
    }
  };
  const escapeHTML = (value) =>
    String(value ?? "").replace(
      /[&<>"']/g,
      (char) =>
        ({
          "&": "&amp;",
          "<": "&lt;",
          ">": "&gt;",
          '"': "&quot;",
          "'": "&#39;",
        })[char],
    );
  const safeURL = (value) => String(value || "").replace(/["'<>]/g, "");
  const money = (value) =>
    Number(value || 0) === 0
      ? "Free"
      : `₱${Number(value).toLocaleString("en-PH")}`;
  const formatDate = (value) => {
    if (!value) return "Date to be announced";
    const date = new Date(`${value}T12:00:00`);
    return date.toLocaleDateString("en-PH", {
      month: "short",
      day: "numeric",
      year: "numeric",
    });
  };
  const formatDateLong = (value) => {
    if (!value) return "Date to be announced";
    const date = new Date(`${value}T12:00:00`);
    return date.toLocaleDateString("en-PH", {
      weekday: "long",
      month: "long",
      day: "numeric",
      year: "numeric",
    });
  };
  const allEvents = () => {
    const removed = new Set(read(KEYS.removed, []));
    const overrides = read(KEYS.overrides, {});
    return [...DATA.events, ...read(KEYS.custom, [])]
      .filter((event) => !removed.has(event.id))
      .map((event) => ({ ...event, ...(overrides[event.id] || {}) }));
  };
  const findEvent = (id) => allEvents().find((event) => event.id === id);
  const profile = () => ({ ...DATA.defaultProfile, ...read(KEYS.profile, {}) });
  const favorites = () => read(KEYS.favorites, []);
  const bookings = () => read(KEYS.bookings, []);
  const icon = (name) =>
    `<i data-lucide="${escapeHTML(name)}" aria-hidden="true"></i>`;
  const rerenderIcons = () => {
    if (window.lucide?.createIcons)
      window.lucide.createIcons({ attrs: { "stroke-width": 1.8 } });
  };

  function toast(message, type = "success") {
    const region = $("[data-toast-region]");
    if (!region) return;
    const item = document.createElement("div");
    item.className = `toast toast-${type}`;
    item.innerHTML = `${icon(type === "error" ? "circle-alert" : "circle-check")}<span>${escapeHTML(message)}</span><button type="button" aria-label="Dismiss notification">${icon("x")}</button>`;
    region.appendChild(item);
    rerenderIcons();
    item.querySelector("button").addEventListener("click", () => item.remove());
    window.setTimeout(() => {
      item.classList.add("toast-leave");
      window.setTimeout(() => item.remove(), 250);
    }, 3600);
  }

  let lastModalTrigger = null;
  let pendingConfirmation = null;
  let currentSuccessBooking = null;
  function showModal(content, onReady) {
    const backdrop = $("[data-modal-backdrop]");
    const container = $("[data-modal-content]");
    if (!backdrop || !container) return;
    lastModalTrigger =
      document.activeElement instanceof HTMLElement
        ? document.activeElement
        : null;
    container.innerHTML = content;
    backdrop.hidden = false;
    document.body.classList.add("modal-open");
    rerenderIcons();
    if (onReady) onReady(container);
    $("[data-modal-close]", backdrop)?.focus();
  }
  function closeModal() {
    const backdrop = $("[data-modal-backdrop]");
    if (pendingConfirmation) {
      const resolve = pendingConfirmation;
      pendingConfirmation = null;
      resolve(false);
    }
    if (backdrop) backdrop.hidden = true;
    document.body.classList.remove("modal-open");
    const trigger = lastModalTrigger;
    lastModalTrigger = null;
    if (trigger?.isConnected) trigger.focus();
  }
  function confirmModal({ title, text, confirm = "Confirm", danger = false }) {
    return new Promise((resolve) => {
      pendingConfirmation = resolve;
      showModal(
        `<span class="modal-icon ${danger ? "modal-icon-danger" : ""}">${icon(danger ? "trash-2" : "circle-help")}</span><span class="section-kicker">PLEASE CONFIRM</span><h2 id="modal-title">${escapeHTML(title)}</h2><p class="modal-copy">${escapeHTML(text)}</p><div class="modal-actions"><button type="button" class="button button-outline" data-modal-close>Go back</button><button type="button" class="button ${danger ? "button-danger" : "button-primary"}" data-confirm-action>${escapeHTML(confirm)}</button></div>`,
        (box) => {
          const finish = (accepted) => {
            if (pendingConfirmation === resolve) pendingConfirmation = null;
            closeModal();
            resolve(accepted);
          };
          box
            .querySelector("[data-confirm-action]")
            .addEventListener("click", () => finish(true));
          box
            .querySelector("[data-modal-close]")
            .addEventListener("click", () => finish(false));
        },
      );
    });
  }

  function eventCard(event, compact = false) {
    const saved = favorites().includes(event.id);
    const image = safeURL(event.image || DATA.imageFallback);
    const popularity = Number(event.popularity || 0);
    const popularityLabel = popularity
      ? `Popularity · ${popularity}% demo`
      : "New listing · demo";
    const seats = Math.max(0, Number(event.demoSeats || 0));
    return `<article class="event-card ${compact ? "event-card-compact" : ""}">
      <div class="event-card-image"><a href="/Events/Details/${encodeURIComponent(event.id)}" aria-label="View ${escapeHTML(event.title)} details"><img src="${image}" alt="Illustrative image for ${escapeHTML(event.title)}" loading="lazy" onerror="this.src='${DATA.imageFallback}'" /></a><span class="event-category-pill">${escapeHTML(event.category)}</span><button class="favorite-button ${saved ? "is-saved" : ""}" type="button" data-favorite="${escapeHTML(event.id)}" aria-label="${saved ? "Remove" : "Save"} ${escapeHTML(event.title)}" aria-pressed="${saved}">${icon("heart")}</button><button class="image-zoom-button" type="button" data-image-zoom="${escapeHTML(event.id)}" aria-label="Zoom image for ${escapeHTML(event.title)}" title="Enlarge sample image">${icon("maximize-2")}</button></div>
      <div class="event-card-body"><div class="event-date-row"><span class="event-date-icon">${icon("calendar-days")}</span><span>Demo date · ${formatDate(event.date)} · ${escapeHTML(event.time || "Time TBA")} (demo)</span></div><h3><a href="/Events/Details/${encodeURIComponent(event.id)}">${escapeHTML(event.title)}</a></h3><div class="event-meta-line">${icon("map-pin")}<span>${escapeHTML(event.location)}${event.province && event.province !== "Metro Manila" ? `, ${escapeHTML(event.province)}` : ""}</span></div>
      <div class="event-demo-cues"><span>${popularityLabel}</span>${event.trending ? "<span>Trending · demo</span>" : ""}<span>Availability · ${seats} sample spots</span></div><div class="event-card-footer"><span class="event-price"><small>Sample price</small><strong>${money(event.price)}${event.price ? "<em> / ticket</em>" : ""}</strong></span><a class="card-arrow" href="/Events/Details/${encodeURIComponent(event.id)}" aria-label="View event details">${icon("arrow-up-right")}</a></div><div class="demo-card-note">Sample listing · No live tickets</div></div>
    </article>`;
  }
  function categoryCard(category) {
    return `<a class="category-card category-${escapeHTML(category.tone)}" href="/Events?category=${encodeURIComponent(category.key)}" data-category-key="${escapeHTML(category.key)}"><span class="category-icon">${icon(category.icon)}</span><span class="category-card-copy"><strong>${escapeHTML(category.name)}</strong><small>${category.count} sample ${category.count === 1 ? "event" : "events"}</small></span><span class="category-arrow">${icon("arrow-up-right")}</span></a>`;
  }
  function populateSelect(select, values, firstLabel) {
    if (!select) return;
    const selected = select.value;
    select.innerHTML =
      `<option value="">${escapeHTML(firstLabel)}</option>` +
      values
        .map(
          (item) =>
            `<option value="${escapeHTML(item)}">${escapeHTML(item)}</option>`,
        )
        .join("");
    if (selected) select.value = selected;
  }
  function initHeader() {
    const toggle = $("[data-menu-toggle]");
    const panel = $("[data-menu-panel]");
    toggle?.addEventListener("click", () => {
      const open = toggle.getAttribute("aria-expanded") === "true";
      toggle.setAttribute("aria-expanded", String(!open));
      toggle.setAttribute(
        "aria-label",
        open ? "Open navigation menu" : "Close navigation menu",
      );
      panel?.classList.toggle("is-open", !open);
      document.body.classList.toggle("nav-open", !open);
    });
    panel?.querySelectorAll("a").forEach((link) =>
      link.addEventListener("click", () => {
        toggle?.setAttribute("aria-expanded", "false");
        panel.classList.remove("is-open");
        document.body.classList.remove("nav-open");
      }),
    );
    const path = location.pathname.toLowerCase();
    const section = path.startsWith("/events")
      ? "events"
      : path.startsWith("/dashboard")
        ? "dashboard"
        : path.startsWith("/organizer")
          ? "organizer"
          : path === "/"
            ? "home"
            : "";
    document.querySelector(`[data-nav="${section}"]`)?.classList.add("active");
    document.addEventListener(
      "scroll",
      () =>
        $("[data-header]")?.classList.toggle(
          "is-scrolled",
          window.scrollY > 16,
        ),
      { passive: true },
    );
  }
  function initGlobalModal() {
    const backdrop = $("[data-modal-backdrop]");
    $("[data-modal-close]", backdrop)?.addEventListener("click", closeModal);
    backdrop?.addEventListener("click", (event) => {
      if (event.target === backdrop) closeModal();
    });
    document.addEventListener("click", (event) => {
      const button = event.target.closest("[data-image-zoom]");
      if (!button) return;
      const item = findEvent(button.dataset.imageZoom);
      if (!item) return;
      showModal(
        `<span class="section-kicker">ILLUSTRATIVE EVENT IMAGE</span><h2 id="modal-title">${escapeHTML(item.title)}</h2><div class="image-zoom-preview"><img src="${safeURL(item.image || DATA.imageFallback)}" alt="Illustrative image for ${escapeHTML(item.title)}" onerror="this.src='${DATA.imageFallback}'"/></div><p class="form-footnote">Sample visual only · event imagery is illustrative.</p><div class="modal-actions"><button type="button" class="button button-outline" data-modal-close>Close</button><a class="button button-primary" href="/Events/Details/${encodeURIComponent(item.id)}">View event details</a></div>`,
      );
    });
    document.addEventListener("keydown", (event) => {
      if (!backdrop || backdrop.hidden) return;
      if (event.key === "Escape") {
        closeModal();
        return;
      }
      if (event.key !== "Tab") return;
      const focusable = $$(
        'a[href],button:not([disabled]),input:not([disabled]),select:not([disabled]),textarea:not([disabled]),[tabindex]:not([tabindex="-1"])',
        backdrop,
      ).filter((element) => element.getClientRects().length > 0);
      if (!focusable.length) {
        event.preventDefault();
        $('[role="dialog"]', backdrop)?.focus();
        return;
      }
      const first = focusable[0];
      const last = focusable[focusable.length - 1];
      if (event.shiftKey && document.activeElement === first) {
        event.preventDefault();
        last.focus();
      } else if (!event.shiftKey && document.activeElement === last) {
        event.preventDefault();
        first.focus();
      }
    });
  }
  function toggleFavorite(id) {
    const current = favorites();
    const next = current.includes(id)
      ? current.filter((item) => item !== id)
      : [...current, id];
    save(KEYS.favorites, next);
    const event = findEvent(id);
    toast(
      next.includes(id)
        ? `${event?.title || "Event"} saved to your favorites.`
        : "Removed from saved events.",
    );
    if (document.body.querySelector('[data-page="home"]')) renderHome();
    if (document.body.querySelector('[data-page="explore"]')) renderExplore();
    if (document.body.querySelector('[data-page="favorites"]'))
      renderFavorites();
    if (document.body.querySelector('[data-page="details"]')) renderDetails();
  }

  function renderHome() {
    const featuredTarget = $("[data-featured-grid]");
    if (!featuredTarget) return;
    const events = allEvents();
    featuredTarget.innerHTML = events
      .filter((event) => event.featured)
      .slice(0, 6)
      .map((event) => eventCard(event))
      .join("");
    $("[data-category-grid]").innerHTML = DATA.categories
      .map(categoryCard)
      .join("");
    $("[data-trending-grid]").innerHTML = events
      .filter((event) => event.trending)
      .sort((a, b) => b.popularity - a.popularity)
      .slice(0, 4)
      .map((event) => eventCard(event, true))
      .join("");
    $("[data-demo-stats]").innerHTML = DATA.demoStats
      .map(
        (stat) =>
          `<div class="stat-item"><span class="stat-icon stat-${stat.tone}">${icon(stat.icon)}</span><strong>${stat.value.toLocaleString("en-PH")}${stat.suffix}</strong><small>${escapeHTML(stat.label)} <em>· demo</em></small></div>`,
      )
      .join("");
    $("[data-testimonials]").innerHTML = DATA.testimonials
      .map(
        (item, index) =>
          `<article class="testimonial-card"><div class="testimonial-stars" aria-label="Five out of five sample stars">★★★★★</div><p>“${escapeHTML(item.quote)}”</p><div class="testimonial-author"><span class="testimonial-avatar avatar-${index}">${escapeHTML(item.initials)}</span><span><strong>${escapeHTML(item.name)} <small>· fictional</small></strong><small>${escapeHTML(item.city)}, Philippines</small></span><i data-lucide="quote"></i></div></article>`,
      )
      .join("");
    const search = $("[data-home-search]");
    if (search) {
      populateSelect(
        search.elements.location,
        DATA.locations,
        "Anywhere in the Philippines",
      );
      populateSelect(
        search.elements.category,
        DATA.categories.map((category) => category.name),
        "All categories",
      );
    }
    rerenderIcons();
  }
  function initHome() {
    renderHome();
    $("[data-home-search]")?.addEventListener("submit", (event) => {
      event.preventDefault();
      const form = event.currentTarget;
      const params = new URLSearchParams();
      const q = form.elements.q.value.trim();
      const locationValue = form.elements.location.value;
      const category = form.elements.category.value;
      const date = form.elements.date.value;
      if (q) params.set("q", q);
      if (locationValue) params.set("location", locationValue);
      if (category) params.set("category", category);
      if (date) params.set("from", date);
      location.href = `/Events${params.toString() ? `?${params}` : ""}`;
    });
    const cards = $("[data-testimonials]");
    let offset = 0;
    const shift = (direction) => {
      const items = $$(".testimonial-card", cards);
      if (!items.length) return;
      offset = (offset + direction + items.length) % items.length;
      cards.style.transform = `translateX(-${offset * 8}px)`;
    };
    $("[data-testimonial-prev]")?.addEventListener("click", () => shift(-1));
    $("[data-testimonial-next]")?.addEventListener("click", () => shift(1));
  }

  let exploreLimit = 8;
  let exploreLoadingTimer = null;
  function exploreSkeletonCard() {
    return `<article class="event-card event-skeleton" aria-hidden="true"><div class="event-card-image skeleton-image"></div><div class="event-card-body"><span class="skeleton-line skeleton-date"></span><span class="skeleton-line skeleton-heading"></span><span class="skeleton-line skeleton-meta"></span><span class="skeleton-line skeleton-price"></span></div></article>`;
  }
  function exploreInputs() {
    const result = {};
    $$("[data-filter]").forEach((input) => {
      result[input.dataset.filter] =
        input.type === "checkbox" ? input.checked : input.value;
    });
    return result;
  }
  function matchesFilters(event, filters) {
    const query = (filters.q || "").trim().toLowerCase();
    if (
      query &&
      !`${event.title} ${event.description} ${event.category} ${event.location} ${event.province} ${event.organizer}`
        .toLowerCase()
        .includes(query)
    )
      return false;
    if (
      filters.location &&
      event.location !== filters.location &&
      event.province !== filters.location &&
      !event.location.includes(filters.location)
    )
      return false;
    if (filters.category && event.category !== filters.category) return false;
    if (filters.from && event.date < filters.from) return false;
    if (filters.to && event.date > filters.to) return false;
    if (filters.price && Number(event.price) > Number(filters.price))
      return false;
    if (filters.free && Number(event.price) > 0) return false;
    return true;
  }
  function filterChip(label, key, value) {
    return `<button type="button" class="filter-chip" data-chip-clear="${key}" aria-label="Remove ${escapeHTML(label)} filter">${escapeHTML(label)} <span>×</span></button>`;
  }
  function renderExplore() {
    const page = $('[data-page="explore"]');
    if (!page) return;
    const firstRender = !page.dataset.initialized;
    const params = new URLSearchParams(location.search);
    if (firstRender) {
      populateSelect(
        $('[data-filter="location"]'),
        DATA.locations,
        "Anywhere in the Philippines",
      );
      populateSelect(
        $('[data-filter="category"]'),
        DATA.categories.map((item) => item.name),
        "All categories",
      );
      ["q", "location", "category", "from", "to"].forEach((key) => {
        const input = $(`[data-filter="${key}"]`);
        if (input && params.has(key)) input.value = params.get(key);
      });
      if (params.get("category") && !$('[data-filter="category"]').value)
        $('[data-filter="category"]').value =
          DATA.categories.find((c) =>
            c.name
              .toLowerCase()
              .startsWith(params.get("category").toLowerCase()),
          )?.name || "";
      if (params.get("sort")) $("[data-sort]").value = params.get("sort");
      page.dataset.initialized = "true";
    }
    const grid = $("[data-event-list]");
    const draw = () => {
      const filters = exploreInputs();
      const sort = $("[data-sort]")?.value || "newest";
      let results = allEvents().filter((event) =>
        matchesFilters(event, filters),
      );
      if (sort === "popular")
        results.sort((a, b) => b.popularity - a.popularity);
      else if (sort === "price-low") results.sort((a, b) => a.price - b.price);
      else if (sort === "price-high") results.sort((a, b) => b.price - a.price);
      else results.sort((a, b) => b.date.localeCompare(a.date));
      $("[data-result-count]").textContent =
        `${results.length} sample ${results.length === 1 ? "event" : "events"}`;
      const chips = [];
      if (filters.q) chips.push(filterChip(`“${filters.q}”`, "q"));
      if (filters.location)
        chips.push(filterChip(filters.location, "location"));
      if (filters.category)
        chips.push(filterChip(filters.category, "category"));
      if (filters.from)
        chips.push(filterChip(`From ${formatDate(filters.from)}`, "from"));
      if (filters.to)
        chips.push(filterChip(`Until ${formatDate(filters.to)}`, "to"));
      if (filters.free) chips.push(filterChip("Free events", "free"));
      if (filters.price && filters.price < 5000)
        chips.push(filterChip(`Up to ${money(filters.price)}`, "price"));
      $("[data-filter-chips]").innerHTML = chips.join("");
      grid.innerHTML = results
        .slice(0, exploreLimit)
        .map((event) => eventCard(event))
        .join("");
      grid.setAttribute("aria-busy", "false");
      grid.removeAttribute("aria-label");
      $("[data-empty-state]").hidden = results.length !== 0;
      $("[data-load-more]").hidden = results.length <= exploreLimit;
      $("[data-price-max]").textContent = money(filters.price || 5000);
      $("[data-load-more]").onclick = () => {
        exploreLimit += 8;
        renderExplore();
      };
      rerenderIcons();
    };
    if (firstRender) {
      grid.setAttribute("aria-busy", "true");
      grid.setAttribute("aria-label", "Loading sample event listings");
      grid.innerHTML = Array.from({ length: 6 }, exploreSkeletonCard).join("");
      exploreLoadingTimer = window.setTimeout(() => {
        exploreLoadingTimer = null;
        draw();
      }, 180);
    } else {
      if (exploreLoadingTimer) {
        window.clearTimeout(exploreLoadingTimer);
        exploreLoadingTimer = null;
      }
      draw();
    }
  }
  function initExplore() {
    const page = $('[data-page="explore"]');
    if (!page) return;
    renderExplore();
    $$("[data-filter]").forEach((input) =>
      input.addEventListener("input", () => {
        exploreLimit = 8;
        renderExplore();
      }),
    );
    $("[data-sort]")?.addEventListener("change", renderExplore);
    document.addEventListener("click", (event) => {
      if (event.target.closest("[data-clear-filters]")) {
        $$("[data-filter]").forEach((input) => {
          if (input.type === "checkbox") input.checked = false;
          else if (input.type === "range") input.value = "5000";
          else input.value = "";
        });
        history.replaceState({}, "", "/Events");
        exploreLimit = 8;
        renderExplore();
      }
      const chip = event.target.closest("[data-chip-clear]");
      if (chip) {
        const input = $(`[data-filter="${chip.dataset.chipClear}"]`);
        if (input) {
          if (input.type === "checkbox") input.checked = false;
          else if (input.type === "range") input.value = "5000";
          else input.value = "";
        }
        renderExplore();
      }
      if (event.target.closest("[data-filter-open]"))
        $("[data-filter-sidebar]")?.classList.add("filter-drawer-open");
      if (event.target.closest("[data-filter-close]"))
        $("[data-filter-sidebar]")?.classList.remove("filter-drawer-open");
    });
  }

  function renderDetails() {
    const page = $('[data-page="details"]');
    if (!page) return;
    const event = findEvent(page.dataset.eventId);
    const target = $("[data-detail-view]");
    if (!event) {
      target.innerHTML = `<div class="not-found-state"><span class="empty-illustration">${icon("map-pin-off")}</span><h1>We can’t find that event.</h1><p>Try another local demo listing.</p><a class="button button-primary" href="/Events">Explore events</a></div>`;
      rerenderIcons();
      return;
    }
    document.title = `${event.title} · Evently`;
    $("[data-breadcrumb-title]").textContent = event.title;
    const ticketOptions = event.tickets || [
      { name: "General Admission", price: event.price },
      {
        name: "Student Ticket",
        price: Math.max(0, Math.round(event.price * 0.6)),
      },
    ];
    const saved = favorites().includes(event.id);
    target.innerHTML = `<section class="detail-banner"><img src="${safeURL(event.image || DATA.imageFallback)}" alt="Illustrative ${escapeHTML(event.category.toLowerCase())} scene for ${escapeHTML(event.title)}" onerror="this.src='${DATA.imageFallback}'"/><div class="detail-banner-shade"></div><div class="detail-banner-label"><span class="event-category-pill">${escapeHTML(event.category)}</span><span class="demo-badge demo-badge-light">DEMO EVENT</span></div><div class="detail-banner-actions"><button class="button button-glass ${saved ? "is-saved" : ""}" data-favorite="${escapeHTML(event.id)}" type="button" aria-pressed="${saved}">${icon("heart")} ${saved ? "Saved" : "Save event"}</button><button class="button button-glass" type="button" data-share-event>${icon("share-2")} Share</button></div><div class="detail-banner-title"><h1>${escapeHTML(event.title)}</h1><p>${icon("map-pin")} ${escapeHTML(event.location)}${event.province ? `, ${escapeHTML(event.province)}` : ""}</p></div></section>
      <div class="detail-columns"><article class="detail-content"><div class="detail-top-facts"><div>${icon("calendar-days")}<span><small>Demo schedule</small><strong>${formatDateLong(event.date)}</strong></span></div><div>${icon("clock-3")}<span><small>Sample start time</small><strong>${escapeHTML(event.time || "Time to be announced")}</strong></span></div><div>${icon("map-pin")}<span><small>Demo venue</small><strong>${escapeHTML(event.venue)}</strong></span></div></div>
      <section class="detail-section"><span class="section-kicker">THE IDEA</span><h2>About this experience</h2><p>${escapeHTML(event.description)}</p><p class="accuracy-note">This is an illustrative demo listing. The event date, venue, organizer, availability, and schedule are not verified or confirmed.</p></section>
      <section class="detail-section"><span class="section-kicker">LITTLE THINGS TO LOOK FORWARD TO</span><h2>Event highlights</h2><ul class="highlight-list">${(event.highlights || []).map((item) => `<li>${icon("check")}<span>${escapeHTML(item)}</span></li>`).join("")}</ul></section>
      <section class="detail-section"><span class="section-kicker">SAMPLE ITINERARY</span><h2>A day at a glance</h2><div class="schedule-list">${(event.schedule || []).map((item, index) => `<div class="schedule-row"><span class="schedule-dot">${index + 1}</span><strong>${escapeHTML(item[0])}</strong><span>${escapeHTML(item[1])}</span></div>`).join("")}</div></section>
      <section class="detail-section"><span class="section-kicker">SAMPLE LINEUP</span><h2>People behind the moments</h2><div class="performer-list">${(
        event.performers || []
      )
        .map(
          (person, index) =>
            `<div class="performer-item"><span class="performer-avatar performer-${index % 4}">${escapeHTML(
              person
                .split(" ")
                .map((word) => word[0])
                .slice(0, 2)
                .join(""),
            )}</span><span><strong>${escapeHTML(person)}</strong><small>Fictional demo profile</small></span></div>`,
        )
        .join("")}</div></section>
      <section class="detail-section venue-panel"><div><span class="section-kicker">LOCATION NOTES</span><h2>Where it could happen</h2><p>${escapeHTML(event.venue)}<br/>${escapeHTML(event.address || `${event.location}, Philippines`)}</p><span class="demo-badge">SAMPLE LOCATION · NOT VERIFIED</span></div><span class="venue-map-icon">${icon("map")}</span></section>
      <section class="detail-section"><span class="section-kicker">SAMPLE HOST</span><h2>Organizer</h2><div class="organizer-profile"><span class="organizer-avatar">${escapeHTML(
        (event.organizer || "SO")
          .split(" ")
          .slice(0, 2)
          .map((w) => w[0])
          .join(""),
      )}</span><span><strong>${escapeHTML(event.organizer || "Sample Organizer")}</strong><small>Fictional organizer profile · demo content</small></span><a class="button button-outline button-small" href="/Organizer">Organizer demo</a></div></section>
      <section class="detail-section"><span class="section-kicker">GOOD TO KNOW</span><h2>Frequently asked questions</h2><div class="faq-list"><details><summary>Is this a confirmed upcoming event?</summary><p>No. This is a demo listing with illustrative event information only. No edition or date is confirmed.</p></details><details><summary>Are the tickets and prices real?</summary><p>No. Ticket names, prices, availability, and checkout are sample data. This site does not sell or reserve real tickets.</p></details><details><summary>Can I contact the organizer?</summary><p>The organizer shown is fictional sample content. This demo does not connect to event organizers.</p></details></div></section></article>
      <aside class="booking-card-wrap"><div class="booking-card"><div class="booking-card-head"><span class="section-kicker">YOUR DEMO RESERVATION</span><span class="demo-badge">SAMPLE TICKETS</span></div><label class="booking-label" for="ticketType">Ticket type</label><select id="ticketType" data-ticket-select>${ticketOptions.map((ticket, index) => `<option value="${index}">${escapeHTML(ticket.name)} · ${money(ticket.price)}</option>`).join("")}</select><div class="ticket-meta"><span>${icon("ticket-check")} Sample ticket quantity</span><strong>${Number(event.demoSeats || 48)} available</strong></div><label class="booking-label">Quantity</label><div class="quantity-control"><button type="button" data-quantity-change="-1" aria-label="Decrease quantity">−</button><input type="number" min="1" max="6" value="1" data-ticket-quantity aria-label="Ticket quantity"/><button type="button" data-quantity-change="1" aria-label="Increase quantity">+</button></div><div class="booking-total-row"><span>Sample total</span><strong data-ticket-total>${money(ticketOptions[0].price)}</strong></div><button type="button" class="button button-primary button-full button-large" data-reserve="${escapeHTML(event.id)}">Reserve demo ticket <i data-lucide="arrow-right"></i></button><p class="booking-card-disclaimer">No real ticket is reserved. All details and prices are demo information.</p></div><div class="booking-help">${icon("shield-check")} <span>Clear demo details. No payment processing.</span></div></aside></div>`;
    target.dataset.ticketPrices = JSON.stringify(
      ticketOptions.map((ticket) => ticket.price),
    );
    rerenderIcons();
  }
  function initDetails() {
    if (!$('[data-page="details"]')) return;
    renderDetails();
    document.addEventListener("click", async (event) => {
      const quantity = event.target.closest("[data-quantity-change]");
      if (quantity) {
        const input = $("[data-ticket-quantity]");
        input.value = Math.max(
          1,
          Math.min(
            6,
            Number(input.value || 1) + Number(quantity.dataset.quantityChange),
          ),
        );
        updateTicketTotal();
      }
      const reserve = event.target.closest("[data-reserve]");
      if (reserve) {
        const page = $('[data-page="details"]');
        const evt = findEvent(reserve.dataset.reserve);
        const select = $("[data-ticket-select]");
        const ticket = (evt.tickets || [])[Number(select.value)];
        const qty = Math.max(
          1,
          Math.min(6, Number($("[data-ticket-quantity]").value || 1)),
        );
        save(KEYS.checkout, {
          eventId: evt.id,
          ticketName: ticket.name,
          unitPrice: ticket.price,
          quantity: qty,
        });
        showModal(
          `<span class="modal-icon">${icon("ticket-check")}</span><span class="section-kicker">READY WHEN YOU ARE</span><h2 id="modal-title">Continue to demo checkout?</h2><p class="modal-copy">You’re selecting ${qty} × ${escapeHTML(ticket.name)} for ${escapeHTML(evt.title)}. This will not reserve a real ticket or process payment.</p><div class="modal-actions"><button class="button button-outline" type="button" data-modal-close>Keep browsing</button><button class="button button-primary" type="button" data-go-checkout>Continue to checkout ${icon("arrow-right")}</button></div>`,
          (box) =>
            box
              .querySelector("[data-go-checkout]")
              .addEventListener("click", () => {
                closeModal();
                location.href = "/Booking/Checkout";
              }),
        );
      }
      if (event.target.closest("[data-share-event]")) {
        const page = $('[data-page="details"]');
        const evt = findEvent(page.dataset.eventId);
        try {
          if (navigator.share)
            await navigator.share({
              title: evt.title,
              text: "Sample Evently demo listing",
              url: location.href,
            });
          else {
            await navigator.clipboard.writeText(location.href);
            toast("Demo event link copied.");
          }
        } catch {
          toast("Share is ready to use from your browser.", "error");
        }
      }
    });
    document.addEventListener("change", (event) => {
      if (
        event.target.matches("[data-ticket-select]") ||
        event.target.matches("[data-ticket-quantity]")
      )
        updateTicketTotal();
    });
  }
  function updateTicketTotal() {
    const page = $('[data-page="details"]');
    if (!page) return;
    const event = findEvent(page.dataset.eventId);
    if (!event) return;
    const ticket = (event.tickets || [])[
      Number($("[data-ticket-select]").value)
    ];
    const qty = Math.max(
      1,
      Math.min(6, Number($("[data-ticket-quantity]").value || 1)),
    );
    $("[data-ticket-total]").textContent = money(ticket.price * qty);
  }

  function renderCheckout() {
    const page = $('[data-page="checkout"]');
    if (!page) return;
    const selection = read(KEYS.checkout, null);
    const event = selection && findEvent(selection.eventId);
    if (!selection || !event) {
      $("[data-checkout-summary]").innerHTML =
        `<div class="empty-state inline-empty"><span class="empty-illustration">${icon("ticket")}</span><h3>No demo ticket selected</h3><p>Choose an event and ticket type first. Nothing is reserved yet.</p><a class="button button-primary" href="/Events">Explore events</a></div>`;
      $("[data-checkout-form]").hidden = true;
      $("[data-checkout-total]").innerHTML = "";
      rerenderIcons();
      return;
    }
    const qty = Math.max(1, Math.min(6, Number(selection.quantity || 1)));
    const total = Number(selection.unitPrice) * qty;
    $("[data-checkout-summary]").innerHTML =
      `<div class="checkout-event-summary"><img src="${safeURL(event.image || DATA.imageFallback)}" alt="Illustrative image for ${escapeHTML(event.title)}" onerror="this.src='${DATA.imageFallback}'"/><div><span class="event-category-pill">${escapeHTML(event.category)}</span><h3>${escapeHTML(event.title)}</h3><p>${icon("calendar-days")} Demo date · ${formatDate(event.date)}</p><p>${icon("map-pin")} ${escapeHTML(event.location)}</p></div></div><div class="ticket-summary-row"><span>${escapeHTML(selection.ticketName)} × ${qty}</span><strong>${money(total)}</strong></div>`;
    $("[data-checkout-total]").innerHTML =
      `<div class="checkout-total-event"><strong>${escapeHTML(event.title)}</strong><small>${escapeHTML(selection.ticketName)} · ${qty} ${qty === 1 ? "ticket" : "tickets"}</small></div><div class="price-line"><span>Sample subtotal</span><strong>${money(total)}</strong></div><div class="price-line"><span>Service fee</span><strong>₱0 <small>demo</small></strong></div><div class="price-line total-line"><span>Total</span><strong>${money(total)}</strong></div>`;
    rerenderIcons();
  }
  function validateField(input) {
    const wrapper = input.closest(".form-field");
    const error = wrapper?.querySelector(".field-error");
    let message = "";
    if (input.required && !String(input.value || "").trim())
      message = "This field is required.";
    else if (
      input.type === "email" &&
      input.value &&
      !/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(input.value)
    )
      message = "Enter a valid email address.";
    else if (
      input.name === "mobile" &&
      input.value &&
      !/^(?:(?:\+?63)|0)9\d{9}$/.test(input.value.replace(/[\s()-]/g, ""))
    )
      message = "Use a Philippine mobile number (09XX… or +639XX…).";
    if (error) {
      if (!error.id) error.id = `${input.id || input.name || "field"}-error`;
      error.textContent = message;
      input.setAttribute("aria-describedby", error.id);
    }
    input.classList.toggle("field-invalid", !!message);
    input.setAttribute("aria-invalid", String(!!message));
    return !message;
  }
  function initCheckout() {
    if (!$('[data-page="checkout"]')) return;
    renderCheckout();
    const form = $("[data-checkout-form]");
    form?.addEventListener("submit", (event) => {
      event.preventDefault();
      const inputs = $$("input[required]", form);
      const valid = inputs.map(validateField).every(Boolean);
      if (!valid) {
        form.querySelector('[aria-invalid="true"]')?.focus();
        return;
      }
      const selection = read(KEYS.checkout, null);
      const evt = selection && findEvent(selection.eventId);
      if (!evt) {
        toast("Choose a demo event before continuing.", "error");
        return;
      }
      const values = Object.fromEntries(new FormData(form).entries());
      const qty = Number(selection.quantity || 1);
      const total = Number(selection.unitPrice) * qty;
      const reference = `EV-DEMO-${Math.random().toString(36).slice(2, 8).toUpperCase()}`;
      const booking = {
        reference,
        eventId: evt.id,
        eventTitle: evt.title,
        eventDate: evt.date,
        eventTime: evt.time,
        venue: evt.venue,
        location: evt.location,
        eventImage: evt.image,
        ticketName: selection.ticketName,
        quantity: qty,
        unitPrice: Number(selection.unitPrice),
        total,
        paymentMethod: values.payment,
        status: "Upcoming",
        createdAt: new Date().toISOString(),
        demo: true,
      };
      save(KEYS.bookings, [booking, ...bookings()]);
      save(KEYS.last, booking);
      try {
        sessionStorage.setItem(
          "evently-checkout-attendee",
          JSON.stringify({ fullName: String(values.fullName || "").trim() }),
        );
      } catch {}
      location.href = "/Booking/Success";
    });
    form
      ?.querySelectorAll("input[required]")
      .forEach((input) =>
        input.addEventListener("blur", () => validateField(input)),
      );
  }
  function renderSuccess() {
    const root = $("[data-success-view]");
    if (!root) return;
    let booking = read(KEYS.last, null);
    if (booking) {
      try {
        const attendee = JSON.parse(
          sessionStorage.getItem("evently-checkout-attendee") || "null",
        );
        sessionStorage.removeItem("evently-checkout-attendee");
        if (attendee?.fullName) booking = { ...booking, attendee };
      } catch {}
    }
    currentSuccessBooking = booking;
    if (!booking) {
      root.innerHTML = `<div class="not-found-state"><span class="success-badge">${icon("ticket-x")}</span><h1>No demo booking found</h1><p>Start by choosing an event. This demo will not create a real reservation.</p><a class="button button-primary" href="/Events">Explore events</a></div>`;
      rerenderIcons();
      return;
    }
    root.innerHTML = `<div class="success-confetti" aria-hidden="true">✦</div><div class="success-content"><span class="success-check">${icon("check")}</span><span class="section-kicker">YOUR SAMPLE RESERVATION IS READY</span><h1>You’re all <span>set.</span></h1><p class="success-lede">A demo booking is saved in this browser. No payment was taken and no real ticket was reserved.</p><div class="ticket-preview"><div class="ticket-preview-main"><span class="demo-badge">DEMO TICKET</span><h2>${escapeHTML(booking.eventTitle)}</h2><div class="ticket-facts"><span>${icon("calendar-days")} ${formatDateLong(booking.eventDate)}</span><span>${icon("map-pin")} ${escapeHTML(booking.location)}</span><span>${icon("ticket")} ${escapeHTML(booking.ticketName)} × ${booking.quantity}</span></div><div class="ticket-reference"><small>DEMO BOOKING REFERENCE</small><strong>${escapeHTML(booking.reference)}</strong></div><div class="ticket-attendee"><span class="ticket-avatar">${escapeHTML(
      (booking.attendee?.fullName || "A")
        .split(" ")
        .map((w) => w[0])
        .slice(0, 2)
        .join(""),
    )}</span><span><small>Attendee</small><strong>${escapeHTML(booking.attendee?.fullName || "Demo guest")}</strong></span><span class="ticket-total"><small>Sample total</small><strong>${money(booking.total)}</strong></span></div></div><div class="ticket-preview-stub"><span>EVENTLY<br/>PHILIPPINES</span><div class="barcode" aria-hidden="true"></div><small>ILLUSTRATIVE<br/>NOT VALID FOR ENTRY</small></div></div><div class="success-actions"><button class="button button-primary button-large" type="button" data-download-ticket>${icon("download")} Download demo ticket</button><a class="button button-outline button-large" href="/Dashboard/Bookings">View my bookings</a><a class="text-link" href="/">Back to home ${icon("arrow-right")}</a></div><div class="success-footnote">${icon("info")} This digital ticket is generated in your browser for demonstration only.</div></div>`;
    rerenderIcons();
  }
  function downloadTicket(booking) {
    const lines = [
      "EVENTLY · DEMO TICKET",
      "NOT VALID FOR ENTRY OR PAYMENT",
      "",
      `Event: ${booking.eventTitle}`,
      `Date: ${formatDateLong(booking.eventDate)} · ${booking.eventTime}`,
      `Venue: ${booking.venue}`,
      `Location: ${booking.location}`,
      `Ticket: ${booking.ticketName} × ${booking.quantity}`,
      `Sample total: ${money(booking.total)}`,
      `Attendee: ${booking.attendee?.fullName || "Demo guest"}`,
      `Reference: ${booking.reference}`,
      "",
      "All event and booking details are sample data.",
    ];
    const blob = new Blob([lines.join("\n")], {
      type: "text/plain;charset=utf-8",
    });
    const url = URL.createObjectURL(blob);
    const anchor = document.createElement("a");
    anchor.href = url;
    anchor.download = `evently-demo-ticket-${booking.reference}.txt`;
    anchor.click();
    URL.revokeObjectURL(url);
    toast("Your demo ticket file is ready.");
  }

  function sidebarMarkup(type, active) {
    const config = {
      user: {
        name: "Alex Santos",
        role: "Event explorer",
        links: [
          ["Overview", "/Dashboard", "layout-dashboard", "dashboard"],
          ["My Bookings", "/Dashboard/Bookings", "ticket", "bookings"],
          ["Saved Events", "/Dashboard/Favorites", "heart", "favorites"],
          ["Profile Settings", "#profile", "user-round", "profile"],
          ["Notifications", "#notifications", "bell", "notifications"],
        ],
      },
      organizer: {
        name: "Sample Organizer",
        role: "Organizer studio",
        links: [
          ["Overview", "/Organizer", "layout-dashboard", "overview"],
          ["My Events", "/Organizer#events", "calendar-days", "events"],
          ["Create Event", "/Organizer/CreateEvent", "circle-plus", "create"],
          ["Attendees", "/Organizer#attendees", "users-round", "attendees"],
          [
            "Analytics",
            "/Organizer#analytics",
            "chart-no-axes-column-increasing",
            "analytics",
          ],
          ["Settings", "/Organizer#settings", "settings-2", "settings"],
        ],
      },
      admin: {
        name: "Demo Admin",
        role: "Administration",
        links: [
          ["Overview", "/Admin", "layout-dashboard", "overview"],
          ["Manage Events", "/Admin#events", "calendar-days", "events"],
          ["Manage Users", "/Admin#users", "users-round", "users"],
          ["Organizers", "/Admin#organizers", "building-2", "organizers"],
          ["Categories", "/Admin#categories", "shapes", "categories"],
          ["Bookings", "/Admin#bookings", "ticket", "bookings"],
          ["Reports", "/Admin#reports", "chart-pie", "reports"],
          ["Settings", "/Admin#settings", "settings-2", "settings"],
        ],
      },
    }[type];
    return `<div class="dashboard-user-card"><span class="profile-avatar">${type === "user" ? escapeHTML(profile().avatar || "AS") : type === "admin" ? "DA" : "SO"}</span><span><strong>${escapeHTML(type === "user" ? profile().name : config.name)}</strong><small>${escapeHTML(config.role)}</small></span><span class="demo-dot"></span></div><span class="sidebar-section-label">WORKSPACE</span><nav class="dashboard-nav" aria-label="${type} dashboard">${config.links.map(([label, url, iconName, key]) => `<a href="${url}" data-dashboard-link="${key}" class="${active === key ? "active" : ""}">${icon(iconName)}<span>${label}</span>${key === "notifications" ? '<span class="notification-count">2</span>' : ""}</a>`).join("")}</nav><div class="sidebar-spacer"></div><div class="sidebar-demo-card"><span>${icon("sparkles")}</span><strong>Demo workspace</strong><p>Changes are stored only in this browser.</p></div><a class="dashboard-logout" href="/">${icon("log-out")}<span>Back to Evently</span></a>`;
  }
  function fillSidebars() {
    const user = $("[data-dashboard-sidebar]");
    if (user)
      user.innerHTML = sidebarMarkup(
        "user",
        document.querySelector('[data-page="dashboard"]')
          ? "dashboard"
          : document.querySelector('[data-page="my-bookings"]')
            ? "bookings"
            : "favorites",
      );
    const org = $("[data-organizer-sidebar]");
    if (org)
      org.innerHTML = sidebarMarkup(
        "organizer",
        document.querySelector('[data-page="create-event"]')
          ? "create"
          : "overview",
      );
    const admin = $("[data-admin-sidebar]");
    if (admin) admin.innerHTML = sidebarMarkup("admin", "overview");
    rerenderIcons();
  }
  function statCard(label, value, iconName, tone, detail = "DEMO DATA") {
    return `<article class="dashboard-stat-card"><span class="dashboard-stat-icon stat-${tone}">${icon(iconName)}</span><span class="dashboard-stat-label">${escapeHTML(label)}</span><strong>${escapeHTML(String(value))}</strong><small>${escapeHTML(detail)}</small></article>`;
  }
  function bookingStatus(booking) {
    if (booking.status === "Cancelled") return "Cancelled";
    const today = new Intl.DateTimeFormat("en-CA", {
      timeZone: "Asia/Manila",
      year: "numeric",
      month: "2-digit",
      day: "2-digit",
    }).format(new Date());
    return booking.eventDate < today ? "Completed" : "Upcoming";
  }
  function bookingCard(booking) {
    const evt = findEvent(booking.eventId) || {
      title: booking.eventTitle,
      image: booking.eventImage,
      location: booking.location,
      date: booking.eventDate,
      venue: booking.venue,
    };
    const status = bookingStatus(booking);
    return `<article class="booking-list-card"><div class="booking-list-image"><img src="${safeURL(evt.image || DATA.imageFallback)}" alt="Illustrative image for ${escapeHTML(evt.title)}" onerror="this.src='${DATA.imageFallback}'"/><span class="booking-status status-${status.toLowerCase()}">${escapeHTML(status)} · demo</span></div><div class="booking-list-copy"><span class="section-kicker">DEMO BOOKING · ${escapeHTML(booking.reference)}</span><h3>${escapeHTML(evt.title)}</h3><p>${icon("calendar-days")} ${formatDate(evt.date)} · ${escapeHTML(evt.time || booking.eventTime || "Demo schedule")}</p><p>${icon("map-pin")} ${escapeHTML(evt.location)} · ${escapeHTML(evt.venue || booking.venue)}</p><div class="booking-card-details"><span>${escapeHTML(booking.ticketName)} × ${booking.quantity}</span><strong>${money(booking.total)}</strong></div><div class="booking-actions"><button type="button" class="text-link" data-view-ticket="${escapeHTML(booking.reference)}">View demo ticket ${icon("arrow-up-right")}</button>${status === "Upcoming" ? `<button type="button" class="text-link booking-cancel" data-cancel-booking="${escapeHTML(booking.reference)}">Cancel demo booking</button>` : ""}</div></div></article>`;
  }
  function openTicketModal(booking) {
    showModal(
      `<span class="modal-icon">${icon("ticket")}</span><span class="section-kicker">DEMO TICKET · NOT VALID FOR ENTRY</span><h2 id="modal-title">${escapeHTML(booking.eventTitle)}</h2><div class="ticket-modal-facts"><p>${icon("calendar-days")} ${formatDateLong(booking.eventDate)}</p><p>${icon("map-pin")} ${escapeHTML(booking.location)} · ${escapeHTML(booking.venue)}</p><p>${icon("ticket")} ${escapeHTML(booking.ticketName)} × ${booking.quantity}</p><p>${icon("hash")} ${escapeHTML(booking.reference)}</p></div><div class="modal-actions"><button class="button button-outline" type="button" data-modal-close>Close</button><button class="button button-primary" type="button" data-download-modal-ticket>Download demo ticket ${icon("download")}</button></div>`,
      (box) =>
        box
          .querySelector("[data-download-modal-ticket]")
          .addEventListener("click", () => downloadTicket(booking)),
    );
  }
  function renderDashboard() {
    const target = $("[data-dashboard-overview]");
    if (!target) return;
    const items = bookings();
    const upcoming = items.filter((item) => bookingStatus(item) === "Upcoming");
    const past = items.filter(
      (item) => bookingStatus(item) === "Completed",
    ).length;
    const saved = favorites().length;
    target.innerHTML = `<div class="dashboard-stat-grid">${statCard("Total bookings", items.length, "ticket", "violet", "SIMULATED")}${statCard("Upcoming events", upcoming.length, "calendar-check", "orange", "SAVED ON THIS DEVICE")}${statCard("Past events", past, "calendar-clock", "mint", "DEMO HISTORY")}${statCard("Saved events", saved, "heart", "yellow", "LOCAL FAVORITES")}</div><div class="dashboard-content-grid"><section class="panel-card dashboard-bookings-panel"><div class="panel-title"><div><span class="section-kicker">YOUR NEXT PLANS</span><h2>Upcoming events</h2></div><a class="text-link" href="/Dashboard/Bookings">All bookings ${icon("arrow-right")}</a></div>${upcoming.length ? `<div class="booking-card-stack">${upcoming.slice(0, 3).map(bookingCard).join("")}</div>` : `<div class="empty-state inline-empty"><span class="empty-illustration">${icon("calendar-heart")}</span><h3>Your next good day is waiting</h3><p>Explore demo events and make a sample reservation.</p><a class="button button-primary" href="/Events">Explore events</a></div>`}</section><section class="panel-card activity-panel"><div class="panel-title"><div><span class="section-kicker">THE LITTLE THINGS</span><h2>Recent activity</h2></div>${icon("activity")}</div><div class="activity-timeline"><div><span class="activity-point activity-violet">${icon("user-round-pen")}</span><span><strong>Profile ready for the demo</strong><small>Sample account · just now</small></span></div>${items.length ? `<div><span class="activity-point activity-mint">${icon("badge-check")}</span><span><strong>Demo booking confirmed</strong><small>${escapeHTML(items[0].eventTitle)} · ${formatDate(items[0].eventDate)}</small></span></div>` : ""}${saved ? `<div><span class="activity-point activity-peach">${icon("heart")}</span><span><strong>${saved} event${saved === 1 ? "" : "s"} saved</strong><small>Your local favorites list</small></span></div>` : ""}<div><span class="activity-point activity-yellow">${icon("sparkles")}</span><span><strong>Welcome to Evently</strong><small>Sample Philippine event discovery</small></span></div></div><button class="button button-outline button-full" type="button" data-edit-profile>Edit demo profile</button></section></div>`;
    $("[data-user-name]").textContent = profile().name.split(" ")[0];
    rerenderIcons();
  }
  function renderBookings() {
    const root = $("[data-bookings-view]");
    if (!root) return;
    const items = bookings();
    root.innerHTML = `<div class="bookings-toolbar"><div class="booking-tabs"><button class="booking-tab active" data-booking-status="all">All <span>${items.length}</span></button><button class="booking-tab" data-booking-status="Upcoming">Upcoming</button><button class="booking-tab" data-booking-status="Completed">Completed</button><button class="booking-tab" data-booking-status="Cancelled">Cancelled</button></div><div class="booking-search-row"><label class="field-icon-wrap">${icon("search")}<input type="search" placeholder="Search bookings" data-booking-search aria-label="Search bookings"/></label><select data-booking-sort aria-label="Sort bookings"><option value="newest">Newest first</option><option value="oldest">Oldest first</option><option value="price-high">Highest total</option></select></div></div><div class="booking-card-stack" data-booking-results></div>`;
    let status = "all";
    const draw = () => {
      let filtered = bookings().filter(
        (item) => status === "all" || bookingStatus(item) === status,
      );
      const query = $("[data-booking-search]").value.toLowerCase();
      if (query)
        filtered = filtered.filter((item) =>
          `${item.eventTitle} ${item.reference} ${bookingStatus(item)}`
            .toLowerCase()
            .includes(query),
        );
      const sort = $("[data-booking-sort]").value;
      if (sort === "oldest") filtered.reverse();
      if (sort === "price-high") filtered.sort((a, b) => b.total - a.total);
      const target = $("[data-booking-results]");
      target.innerHTML = filtered.length
        ? filtered.map(bookingCard).join("")
        : `<div class="empty-state inline-empty"><span class="empty-illustration">${icon("ticket-x")}</span><h3>No bookings in this view</h3><p>Try another status or explore an event to create a demo reservation.</p><a class="button button-primary" href="/Events">Explore events</a></div>`;
      rerenderIcons();
    };
    $$("[data-booking-status]", root).forEach((button) =>
      button.addEventListener("click", () => {
        $$("[data-booking-status]", root).forEach((item) =>
          item.classList.remove("active"),
        );
        button.classList.add("active");
        status = button.dataset.bookingStatus;
        draw();
      }),
    );
    $("[data-booking-search]", root).addEventListener("input", draw);
    $("[data-booking-sort]", root).addEventListener("change", draw);
    draw();
  }
  function initBookingCancellations() {
    document.addEventListener("click", async (event) => {
      const button = event.target.closest("[data-cancel-booking]");
      if (!button) return;
      const reference = button.dataset.cancelBooking;
      const booking = bookings().find((item) => item.reference === reference);
      if (!booking || bookingStatus(booking) !== "Upcoming") return;
      const yes = await confirmModal({
        title: "Cancel this demo booking?",
        text: "This changes only the sample booking saved in this browser. No real ticket or payment is affected.",
        confirm: "Cancel demo booking",
        danger: true,
      });
      if (!yes) return;
      save(
        KEYS.bookings,
        bookings().map((item) =>
          item.reference === reference
            ? { ...item, status: "Cancelled" }
            : item,
        ),
      );
      renderDashboard();
      renderBookings();
      toast("Demo booking marked as cancelled.");
    });
  }
  function renderFavorites() {
    const root = $("[data-favorites-view]");
    if (!root) return;
    const query = $("[data-favorites-search]")?.value.toLowerCase() || "";
    const saved = favorites()
      .map(findEvent)
      .filter(Boolean)
      .filter((event) =>
        `${event.title} ${event.location} ${event.category}`
          .toLowerCase()
          .includes(query),
      );
    root.innerHTML = saved.length
      ? `<div class="event-grid saved-event-grid">${saved.map((event) => eventCard(event)).join("")}</div>`
      : `<div class="empty-state favorites-empty"><span class="empty-illustration">${icon("heart")}</span><h3>${favorites().length ? "No matching saved events" : "Your saved list is ready for a first favorite"}</h3><p>${favorites().length ? "Try a different search." : "Tap the heart on an event you love and we’ll keep it here in this browser."}</p><a class="button button-primary" href="/Events">Explore events</a></div>`;
    rerenderIcons();
  }
  function initAttendee() {
    if (!document.querySelector("[data-dashboard-sidebar]")) return;
    fillSidebars();
    renderDashboard();
    renderBookings();
    renderFavorites();
    $("[data-favorites-search]")?.addEventListener("input", renderFavorites);
    document.addEventListener("click", (event) => {
      const ticketButton = event.target.closest("[data-view-ticket]");
      if (ticketButton) {
        const booking = bookings().find(
          (item) => item.reference === ticketButton.dataset.viewTicket,
        );
        if (booking) openTicketModal(booking);
      }
      if (event.target.closest("[data-edit-profile]")) openProfileModal();
      const link = event.target.closest("[data-dashboard-link]");
      if (
        link &&
        ["profile", "notifications"].includes(link.dataset.dashboardLink)
      ) {
        event.preventDefault();
        if (link.dataset.dashboardLink === "profile") openProfileModal();
        else openNotifications();
      }
    });
  }
  function openProfileModal() {
    const current = profile();
    showModal(
      `<span class="modal-icon">${icon("user-round-pen")}</span><span class="section-kicker">DEMO PROFILE</span><h2 id="modal-title">Edit your profile</h2><form class="profile-edit-form" data-profile-form><label class="form-field"><span>Full name</span><input name="name" value="${escapeHTML(current.name)}" required/></label><label class="form-field"><span>Email</span><input name="email" type="email" value="${escapeHTML(current.email)}" required/></label><label class="form-field"><span>Mobile</span><input name="mobile" value="${escapeHTML(current.mobile)}"/></label><label class="form-field"><span>City</span><input name="city" value="${escapeHTML(current.city)}"/></label><div class="modal-actions"><button class="button button-outline" type="button" data-modal-close>Cancel</button><button class="button button-primary" type="submit">Save demo profile</button></div></form><p class="form-footnote">Saved locally in this browser; no account service is connected.</p>`,
      (box) =>
        box
          .querySelector("[data-profile-form]")
          .addEventListener("submit", (event) => {
            event.preventDefault();
            const data = Object.fromEntries(new FormData(event.currentTarget));
            const updated = {
              ...current,
              ...data,
              avatar: data.name
                .split(" ")
                .map((w) => w[0])
                .slice(0, 2)
                .join("")
                .toUpperCase(),
            };
            save(KEYS.profile, updated);
            closeModal();
            fillSidebars();
            renderDashboard();
            toast("Demo profile updated.");
          }),
    );
  }
  function openNotifications() {
    showModal(
      `<span class="modal-icon">${icon("bell")}</span><span class="section-kicker">DEMO NOTIFICATIONS</span><h2 id="modal-title">You’re all caught up.</h2><div class="notification-list"><article>${icon("sparkles")}<span><strong>Explore a new local favorite</strong><small>Sample suggestion · Today</small></span></article><article>${icon("heart")}<span><strong>Your saved events are right here</strong><small>Local demo reminder · Today</small></span></article></div><div class="modal-actions"><button class="button button-primary" type="button" data-modal-close>Done</button></div>`,
    );
  }

  function organizerEvents() {
    return allEvents().filter((event) => event.id.startsWith("custom-"));
  }
  function updateEventRecord(record, values) {
    const updates = { ...values };
    if (Object.prototype.hasOwnProperty.call(updates, "price"))
      updates.price = Number(updates.price || 0);
    if (record.id.startsWith("custom-")) {
      const stored = read(KEYS.custom, []);
      save(
        KEYS.custom,
        stored.map((item) =>
          item.id === record.id ? { ...item, ...record, ...updates } : item,
        ),
      );
      const overrides = read(KEYS.overrides, {});
      delete overrides[record.id];
      save(KEYS.overrides, overrides);
    } else {
      const overrides = read(KEYS.overrides, {});
      save(KEYS.overrides, {
        ...overrides,
        [record.id]: { ...(overrides[record.id] || {}), ...updates },
      });
    }
  }
  function removeEventRecord(id) {
    if (id.startsWith("custom-"))
      save(
        KEYS.custom,
        read(KEYS.custom, []).filter((item) => item.id !== id),
      );
    else save(KEYS.removed, [...new Set([...read(KEYS.removed, []), id])]);
    const moderation = read(KEYS.moderation, {});
    delete moderation[id];
    save(KEYS.moderation, moderation);
  }
  function drawChart(id, type, labels, data, label, color) {
    const canvas = document.getElementById(id);
    if (!canvas) return;
    if (window.Chart) {
      new Chart(canvas, {
        type,
        data: {
          labels,
          datasets: [
            {
              label,
              data,
              backgroundColor:
                type === "line"
                  ? `${color}22`
                  : labels.map(
                      (_, i) =>
                        [color, "#FF914D", "#42D6A4", "#FFD166", "#9275FF"][
                          i % 5
                        ],
                    ),
              borderColor: color,
              borderWidth: type === "line" ? 2 : 0,
              fill: type === "line",
              tension: 0.36,
              borderRadius: type === "bar" ? 8 : 0,
              pointBackgroundColor: color,
            },
          ],
        },
        options: {
          responsive: true,
          maintainAspectRatio: false,
          plugins: {
            legend: {
              display: type === "doughnut",
              position: "bottom",
              labels: {
                usePointStyle: true,
                boxWidth: 8,
                font: { family: "Inter", size: 11 },
              },
            },
          },
          scales:
            type === "doughnut"
              ? {}
              : {
                  x: {
                    grid: { display: false },
                    ticks: {
                      color: "#8991a1",
                      font: { family: "Inter", size: 10 },
                    },
                  },
                  y: {
                    grid: { color: "#eef0f5" },
                    ticks: {
                      color: "#8991a1",
                      font: { family: "Inter", size: 10 },
                    },
                    beginAtZero: true,
                  },
                },
        },
      });
    } else {
      canvas.parentElement.innerHTML = `<div class="chart-fallback">${labels.map((name, i) => `<div><span>${escapeHTML(name)}</span><span class="fallback-bar"><i style="width:${Math.max(12, Math.min(100, data[i] * 4))}%"></i></span><strong>${data[i]}</strong></div>`).join("")}</div>`;
    }
  }
  function organizerTableRow(event, index) {
    const sold = Math.max(
      8,
      Math.floor((event.demoSeats || 40) * (0.28 + index * 0.07)),
    );
    return `<tr><td><div class="table-event-cell"><img src="${safeURL(event.image || DATA.imageFallback)}" alt=""/><span><strong>${escapeHTML(event.title)}</strong><small>${escapeHTML(event.category)} · sample</small></span></div></td><td>${formatDate(event.date)}</td><td>${escapeHTML(event.location)}</td><td>${sold} / ${event.demoSeats || 48} <small class="table-muted">demo</small></td><td><span class="status-pill status-published">${event.status === "draft" ? "Draft" : "Demo listing"}</span></td><td><div class="table-actions"><a href="/Events/Details/${encodeURIComponent(event.id)}" aria-label="View ${escapeHTML(event.title)}">${icon("eye")}</a><button type="button" data-edit-event="${escapeHTML(event.id)}" aria-label="Edit ${escapeHTML(event.title)}">${icon("pencil")}</button><button type="button" data-delete-event="${escapeHTML(event.id)}" aria-label="Delete ${escapeHTML(event.title)}">${icon("trash-2")}</button></div></td></tr>`;
  }
  function renderOrganizer() {
    const root = $("[data-organizer-overview]");
    if (!root) return;
    const custom = organizerEvents();
    const items = custom.length ? custom : allEvents().slice(0, 5);
    const settings = read(KEYS.organizerSettings, {
      displayName: "Sample Organizer",
      email: "organizer@evently.demo",
      city: "Manila",
    });
    root.innerHTML = `<div class="dashboard-stat-grid">${statCard("Sample events", custom.length || 5, "calendar-days", "violet", "DEMO LISTINGS")}${statCard("Registrations", custom.reduce((sum, event) => sum + (event.demoSeats || 0), 0) || 312, "users-round", "orange", "SIMULATED")}${statCard("Upcoming", items.filter((event) => event.date >= new Date().toISOString().slice(0, 10)).length, "calendar-check", "mint", "SAMPLE SCHEDULES")}${statCard("Estimated revenue", "₱" + (custom.reduce((sum, event) => sum + (event.price || 0) * (event.demoSeats || 0), 0) || 187500).toLocaleString("en-PH"), "wallet", "yellow", "ILLUSTRATIVE")}</div><section class="analytics-section" id="analytics"><div class="section-heading"><div><span class="section-kicker">A SNAPSHOT, NOT A FORECAST</span><h2>Sample analytics</h2></div><span class="demo-badge">DEMO DATA ONLY</span></div><div class="analytics-grid"><article class="panel-card chart-card"><div class="chart-heading"><h3>Registrations over time</h3><span>Sample attendees</span></div><div class="chart-canvas-wrap"><canvas id="registrationChart" aria-label="Demo registrations over time" role="img"></canvas></div></article><article class="panel-card chart-card"><div class="chart-heading"><h3>Category mix</h3><span>Illustrative distribution</span></div><div class="chart-canvas-wrap chart-doughnut-wrap"><canvas id="categoryChart" aria-label="Demo event category distribution" role="img"></canvas></div></article><article class="panel-card chart-card"><div class="chart-heading"><h3>Sample ticket sales</h3><span>Not real sales</span></div><div class="chart-canvas-wrap"><canvas id="salesChart" aria-label="Demo sample ticket sales" role="img"></canvas></div></article><article class="panel-card chart-card"><div class="chart-heading"><h3>Monthly performance</h3><span>Illustrative totals</span></div><div class="chart-canvas-wrap"><canvas id="performanceChart" aria-label="Demo monthly performance" role="img"></canvas></div></article></div></section><section class="panel-card data-table-panel" id="events"><div class="panel-title"><div><span class="section-kicker">YOUR LISTINGS</span><h2>Manage events</h2></div><a class="button button-primary button-small" href="/Organizer/CreateEvent">${icon("plus")} Create event</a></div><div class="table-scroll"><table class="data-table"><thead><tr><th>Event name</th><th>Demo date</th><th>Location</th><th>Sample tickets</th><th>Status</th><th>Actions</th></tr></thead><tbody>${items.map(organizerTableRow).join("")}</tbody></table></div><div class="table-footnote">All counts, tickets and revenue are illustrative sample data.</div></section><section class="panel-card data-table-panel" id="attendees"><div class="panel-title"><div><span class="section-kicker">ILLUSTRATIVE ATTENDEE LIST</span><h2>Recent sample attendees</h2></div><span class="demo-badge">FICTIONAL RECORDS</span></div><div class="table-scroll"><table class="data-table"><thead><tr><th>Attendee</th><th>Demo event</th><th>Ticket</th><th>Status</th></tr></thead><tbody><tr><td><strong>Mika R.</strong><small class="table-muted">sample attendee</small></td><td>Manila Creative Week</td><td>General · 1</td><td><span class="status-pill status-published">Demo RSVP</span></td></tr><tr><td><strong>Paolo D.</strong><small class="table-muted">sample attendee</small></td><td>Sunset Sessions: Manila</td><td>Early Bird · 2</td><td><span class="status-pill status-published">Demo RSVP</span></td></tr><tr><td><strong>Sam L.</strong><small class="table-muted">sample attendee</small></td><td>Weekend Food Crawl</td><td>Community · 1</td><td><span class="status-pill status-published">Demo RSVP</span></td></tr></tbody></table></div><p class="table-footnote">Names, events and registrations are fictional sample records; there are no actual attendees.</p></section><section class="panel-card organizer-settings-panel" id="settings"><div><span class="section-kicker">LOCAL STUDIO PREFERENCES</span><h2>Organizer settings</h2><p><strong>${escapeHTML(settings.displayName)}</strong> · ${escapeHTML(settings.email)} · ${escapeHTML(settings.city)}</p><p class="table-footnote">These sample preferences are saved only in this browser and are not connected to a real organizer account.</p></div><button type="button" class="button button-outline" data-edit-organizer-settings>${icon("settings-2")} Edit demo settings</button></section>`;
    drawChart(
      "registrationChart",
      "line",
      ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
      [18, 32, 26, 48, 41, 63],
      "Demo registrations",
      "#7657F6",
    );
    drawChart(
      "categoryChart",
      "doughnut",
      ["Music", "Festivals", "Food", "Arts", "Other"],
      [24, 21, 19, 16, 20],
      "Sample categories",
      "#7657F6",
    );
    drawChart(
      "salesChart",
      "bar",
      ["General", "Student", "VIP", "Group"],
      [42, 26, 18, 11],
      "Sample tickets",
      "#FF914D",
    );
    drawChart(
      "performanceChart",
      "bar",
      ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
      [24, 31, 27, 39, 46, 58],
      "Sample performance",
      "#42D6A4",
    );
    rerenderIcons();
  }
  function initOrganizer() {
    if (!$("[data-organizer-sidebar]")) return;
    fillSidebars();
    renderOrganizer();
    document.addEventListener("click", async (event) => {
      const del = event.target.closest("[data-delete-event]");
      if (del) {
        const yes = await confirmModal({
          title: "Delete this demo listing?",
          text: "This removes the sample event from this browser only. No real listing is affected.",
          confirm: "Delete listing",
          danger: true,
        });
        if (yes) {
          removeEventRecord(del.dataset.deleteEvent);
          renderOrganizer();
          toast("Demo listing removed.");
        }
      }
      const edit = event.target.closest("[data-edit-event]");
      if (edit) {
        const record = findEvent(edit.dataset.editEvent);
        if (record) editEventModal(record);
      }
      if (event.target.closest("[data-edit-organizer-settings]"))
        openOrganizerSettings();
    });
  }
  function editEventModal(record) {
    showModal(
      `<span class="modal-icon">${icon("pencil")}</span><span class="section-kicker">LOCAL DEMO EDIT</span><h2 id="modal-title">Edit listing</h2><form data-event-edit-form><label class="form-field"><span>Event title</span><input name="title" value="${escapeHTML(record.title)}" required/></label><label class="form-field"><span>Location</span><input name="location" value="${escapeHTML(record.location)}" required/></label><div class="modal-actions"><button type="button" class="button button-outline" data-modal-close>Cancel</button><button type="submit" class="button button-primary">Save changes</button></div></form>`,
      (box) =>
        box
          .querySelector("[data-event-edit-form]")
          .addEventListener("submit", (event) => {
            event.preventDefault();
            const values = Object.fromEntries(
              new FormData(event.currentTarget),
            );
            updateEventRecord(record, values);
            closeModal();
            renderOrganizer();
            toast("Demo listing updated.");
          }),
    );
  }
  function openOrganizerSettings() {
    const current = read(KEYS.organizerSettings, {
      displayName: "Sample Organizer",
      email: "organizer@evently.demo",
      city: "Manila",
    });
    showModal(
      `<span class="modal-icon">${icon("settings-2")}</span><span class="section-kicker">SAMPLE STUDIO SETTINGS</span><h2 id="modal-title">Organizer preferences</h2><form data-organizer-settings-form><label class="form-field"><span>Display name</span><input name="displayName" value="${escapeHTML(current.displayName)}" required/></label><label class="form-field"><span>Contact email</span><input name="email" type="email" value="${escapeHTML(current.email)}" required/></label><label class="form-field"><span>City</span><input name="city" value="${escapeHTML(current.city)}" required/></label><div class="modal-actions"><button type="button" class="button button-outline" data-modal-close>Cancel</button><button type="submit" class="button button-primary">Save locally</button></div></form><p class="form-footnote">Demo preferences only; no messages or account updates will be sent.</p>`,
      (box) =>
        box
          .querySelector("[data-organizer-settings-form]")
          .addEventListener("submit", (event) => {
            event.preventDefault();
            const form = event.currentTarget;
            if (!form.reportValidity()) return;
            save(
              KEYS.organizerSettings,
              Object.fromEntries(new FormData(form)),
            );
            closeModal();
            renderOrganizer();
            toast("Sample organizer preferences saved in this browser.");
          }),
    );
  }

  function ticketRow(
    ticket = { name: "General Admission", price: 500, quantity: 60 },
  ) {
    return `<div class="ticket-type-row"><label class="form-field"><span>Ticket type</span><input name="ticketName" value="${escapeHTML(ticket.name)}" placeholder="General Admission" required/></label><label class="form-field"><span>Price (₱)</span><input name="ticketPrice" type="number" min="0" step="50" value="${Number(ticket.price || 0)}" required/></label><label class="form-field"><span>Quantity</span><input name="ticketQuantity" type="number" min="1" value="${Number(ticket.quantity || 60)}" required/></label><button type="button" class="icon-button ticket-remove" data-remove-ticket aria-label="Remove ticket type">${icon("x")}</button></div>`;
  }
  function initCreateEvent() {
    const form = $("[data-create-event-form]");
    if (!form) return;
    fillSidebars();
    populateSelect(
      form.elements.category,
      DATA.categories.map((item) => item.name),
      "Choose a category",
    );
    populateSelect(form.elements.city, DATA.locations, "Select a city");
    const ticketList = $("[data-ticket-type-list]");
    ticketList.innerHTML = ticketRow();
    rerenderIcons();
    const draftPanel = document.createElement("section");
    draftPanel.className = "panel-card saved-drafts-panel";
    draftPanel.setAttribute("aria-label", "Saved demo drafts");
    let editingDraftId = null;
    let bannerData = "";
    function renderDrafts() {
      const drafts = read(KEYS.drafts, []);
      if (!drafts.length) {
        draftPanel.remove();
        return;
      }
      if (!draftPanel.isConnected)
        form.parentElement.insertBefore(draftPanel, form);
      draftPanel.innerHTML = `<div class="panel-title"><div><span class="section-kicker">LOCAL WORK IN PROGRESS</span><h2>Saved event drafts</h2></div><span class="demo-badge">${drafts.length} · demo</span></div><div class="saved-drafts-list">${drafts.map((draft) => `<article class="saved-draft-row"><span><strong>${escapeHTML(draft.title || "Untitled demo draft")}</strong><small>${escapeHTML(draft.category || "Category not set")} · saved in this browser</small></span><div class="saved-draft-actions"><button class="button button-outline button-small" type="button" data-load-draft="${escapeHTML(draft.id)}">Continue editing</button><button class="button button-outline button-small" type="button" data-delete-draft="${escapeHTML(draft.id)}" aria-label="Delete draft ${escapeHTML(draft.title || "Untitled")}">Delete</button></div></article>`).join("")}</div><p class="table-footnote">Drafts are available only in this browser; no event is published until you confirm.</p>`;
      rerenderIcons();
    }
    function setBannerPreview() {
      const preview = $("[data-banner-preview]");
      preview.innerHTML = bannerData
        ? `<img src="${safeURL(bannerData)}" alt="Selected demo event banner preview"/>`
        : `<span class="preview-placeholder">${icon("image-plus")}<small>Your event banner appears here</small></span>`;
      rerenderIcons();
    }
    function loadDraft(draft) {
      editingDraftId = draft.id;
      [
        "title",
        "category",
        "description",
        "date",
        "deadline",
        "startTime",
        "endTime",
        "venue",
        "city",
        "province",
        "address",
        "organizer",
        "organizerEmail",
        "organizerPhone",
        "organizerLink",
      ].forEach((name) => {
        if (form.elements[name]) form.elements[name].value = draft[name] || "";
      });
      bannerData =
        draft.image && draft.image !== DATA.imageFallback ? draft.image : "";
      setBannerPreview();
      const tickets = draft.tickets?.length
        ? draft.tickets
        : [
            {
              name: "General Admission",
              price: draft.price || 0,
              quantity: draft.demoSeats || 60,
            },
          ];
      ticketList.innerHTML = tickets
        .map((ticket) => ticketRow(ticket))
        .join("");
      rerenderIcons();
      form.elements.title.focus();
      toast(
        "Saved demo draft loaded. Continue editing, save again, or review it for publishing.",
      );
    }
    draftPanel.addEventListener("click", async (event) => {
      const open = event.target.closest("[data-load-draft]");
      if (open) {
        const draft = read(KEYS.drafts, []).find(
          (item) => item.id === open.dataset.loadDraft,
        );
        if (draft) loadDraft(draft);
        return;
      }
      const remove = event.target.closest("[data-delete-draft]");
      if (remove) {
        const draft = read(KEYS.drafts, []).find(
          (item) => item.id === remove.dataset.deleteDraft,
        );
        if (!draft) return;
        const yes = await confirmModal({
          title: "Delete this saved draft?",
          text: "This removes the unfinished sample listing from this browser only.",
          confirm: "Delete draft",
          danger: true,
        });
        if (!yes) return;
        save(
          KEYS.drafts,
          read(KEYS.drafts, []).filter((item) => item.id !== draft.id),
        );
        if (editingDraftId === draft.id) editingDraftId = null;
        renderDrafts();
        toast("Saved draft removed.");
      }
    });
    renderDrafts();
    $("[data-add-ticket]").addEventListener("click", () => {
      const wrap = document.createElement("div");
      wrap.innerHTML = ticketRow({ name: "", price: 0, quantity: 40 });
      ticketList.append(wrap.firstElementChild);
      rerenderIcons();
    });
    document.addEventListener("click", (event) => {
      const remove = event.target.closest("[data-remove-ticket]");
      if (remove) {
        if ($$(".ticket-type-row", ticketList).length === 1) {
          toast("Keep at least one ticket type.", "error");
          return;
        }
        remove.closest(".ticket-type-row").remove();
      }
    });
    const bannerInput = form.elements.banner;
    bannerInput.addEventListener("change", () => {
      const file = bannerInput.files?.[0];
      if (!file) return;
      if (!file.type.startsWith("image/")) {
        toast("Choose a JPG, PNG, or other image file.", "error");
        return;
      }
      const reader = new FileReader();
      reader.onload = () => {
        const image = new Image();
        image.onload = () => {
          const canvas = document.createElement("canvas");
          const scale = Math.min(1, 900 / image.width);
          canvas.width = Math.round(image.width * scale);
          canvas.height = Math.round(image.height * scale);
          canvas
            .getContext("2d")
            .drawImage(image, 0, 0, canvas.width, canvas.height);
          bannerData = canvas.toDataURL("image/jpeg", 0.78);
          setBannerPreview();
        };
        image.src = reader.result;
      };
      reader.readAsDataURL(file);
    });
    function collect() {
      const tickets = $$(".ticket-type-row", form).map((row) => ({
        name: row.querySelector('[name="ticketName"]').value.trim(),
        price: Number(row.querySelector('[name="ticketPrice"]').value || 0),
        quantity: Number(
          row.querySelector('[name="ticketQuantity"]').value || 0,
        ),
      }));
      const values = Object.fromEntries(new FormData(form).entries());
      return {
        id: editingDraftId || `custom-${Date.now()}`,
        title: values.title,
        category: values.category,
        date: values.date,
        time: values.startTime,
        endTime: values.endTime,
        location: values.city,
        province: values.province,
        venue: values.venue,
        address: values.address,
        price: tickets[0]?.price || 0,
        organizer: `Sample Organizer · ${values.organizer}`,
        description: values.description,
        highlights: [
          "Organizer-created sample listing",
          "Local demo event details",
        ],
        schedule: [
          [values.startTime || "TBA", "Sample event start"],
          [values.endTime || "TBA", "Sample event end"],
        ],
        performers: [`Sample host · ${values.organizer}`],
        image: bannerData || DATA.imageFallback,
        popularity: 0,
        featured: false,
        trending: false,
        demoSeats: tickets.reduce((sum, item) => sum + item.quantity, 0),
        tickets,
        status: "draft",
        demo: true,
        deadline: values.deadline,
        organizerEmail: values.organizerEmail,
        organizerPhone: values.organizerPhone,
        organizerLink: values.organizerLink,
      };
    }
    const required = [
      "title",
      "category",
      "description",
      "date",
      "startTime",
      "venue",
      "city",
      "province",
      "organizer",
      "organizerEmail",
    ];
    function valid() {
      let ok = true;
      required.forEach((name) => {
        const input = form.elements[name];
        if (input && !validateField(input)) ok = false;
      });
      $$(".ticket-type-row input", form).forEach((input) => {
        if (!validateField(input)) ok = false;
      });
      return ok;
    }
    $("[data-save-draft]").addEventListener("click", () => {
      const draft = collect();
      draft.status = "draft";
      const drafts = read(KEYS.drafts, []).filter(
        (item) => item.id !== draft.id,
      );
      save(KEYS.drafts, [draft, ...drafts]);
      editingDraftId = draft.id;
      renderDrafts();
      toast("Draft saved in this browser.");
    });
    form.addEventListener("submit", (event) => {
      event.preventDefault();
      if (!valid()) {
        form.querySelector('[aria-invalid="true"]')?.focus();
        toast("Check the highlighted fields before publishing.", "error");
        return;
      }
      const listing = collect();
      showModal(
        `<span class="modal-icon">${icon("send")}</span><span class="section-kicker">READY TO SHARE?</span><h2 id="modal-title">Publish this demo listing?</h2><p class="modal-copy">${escapeHTML(listing.title)} will be saved as a local demo event. It will not be posted publicly or create a real event.</p><div class="modal-actions"><button type="button" class="button button-outline" data-modal-close>Keep editing</button><button type="button" class="button button-primary" data-publish-event>Publish demo listing ${icon("arrow-right")}</button></div>`,
        (box) =>
          box
            .querySelector("[data-publish-event]")
            .addEventListener("click", () => {
              listing.status = "published";
              save(KEYS.custom, [
                listing,
                ...organizerEvents().filter((item) => item.id !== listing.id),
              ]);
              save(
                KEYS.drafts,
                read(KEYS.drafts, []).filter((item) => item.id !== listing.id),
              );
              closeModal();
              toast("Your sample listing is now in the demo.");
              location.href = "/Organizer";
            }),
      );
    });
  }

  function renderAdmin() {
    const root = $("[data-admin-overview]");
    if (!root) return;
    const events = allEvents();
    const mod = read(KEYS.moderation, {});
    root.innerHTML = `<div class="dashboard-stat-grid">${statCard("Sample users", "1,284", "users-round", "violet", "DEMO ACCOUNTS")}${statCard("Total events", events.length, "calendar-days", "orange", "SAMPLE LISTINGS")}${statCard("Organizers", "84", "building-2", "mint", "FICTIONAL")}${statCard("Bookings", bookings().length, "ticket", "yellow", "LOCAL SIMULATIONS")}${statCard("Revenue", "₱248,600", "wallet", "peach", "SIMULATED TOTAL")}</div><div class="admin-tools"><label class="field-icon-wrap">${icon("search")}<input type="search" placeholder="Search demo events" data-admin-search aria-label="Search sample event records"/></label><select data-admin-category><option value="">All categories</option></select><select data-admin-status><option value="">All demo statuses</option><option value="pending">Pending review</option><option value="approved">Approved</option><option value="rejected">Rejected</option></select><select data-admin-sort><option value="name">Sort: name</option><option value="price">Sort: price</option><option value="date">Sort: date</option></select><span class="demo-badge">SAMPLE DATA</span></div><section class="panel-card data-table-panel" id="events"><div class="panel-title"><div><span class="section-kicker">LOCAL MODERATION WORKSPACE</span><h2>Manage demo events</h2></div><button class="button button-outline button-small" type="button" data-reset-demo>${icon("rotate-ccw")} Reset demo</button></div><div class="table-scroll"><table class="data-table admin-table"><thead><tr><th>Event</th><th>Demo date</th><th>Location</th><th>Sample price</th><th>Review state</th><th>Local actions</th></tr></thead><tbody data-admin-rows></tbody></table></div><div class="admin-pagination" data-admin-pagination></div><div class="table-footnote">All totals, accounts, events and status changes are simulated locally. No real users or revenue are represented.</div></section><section class="admin-lower-grid"><article class="panel-card" id="users"><span class="section-kicker">SAMPLE ACCOUNTS</span><h2>Demo users</h2><div class="admin-user-row"><span class="profile-avatar">AS</span><span><strong>${escapeHTML(profile().name)}</strong><small>Attendee · sample profile</small></span><button type="button" class="button button-outline button-small" data-user-detail>View details</button></div><div class="admin-user-row"><span class="profile-avatar avatar-orange">SO</span><span><strong>Sample Organizer</strong><small data-organizer-demo-status>Organizer · fictional</small></span><button type="button" class="button button-outline button-small" data-suspend-demo>Suspend demo account</button></div></article><article class="panel-card" id="reports"><span class="section-kicker">REPORTS</span><h2>Sample platform activity</h2><div class="admin-report-bars"><div><span>Event discovery</span><i><b style="width:78%"></b></i><strong>78%</strong></div><div><span>Saved events</span><i><b style="width:53%"></b></i><strong>53%</strong></div><div><span>Demo bookings</span><i><b style="width:36%"></b></i><strong>36%</strong></div></div><p class="table-footnote">Illustrative display values only; not real analytics.</p></article></section><section class="admin-lower-grid admin-extra-grid"><article class="panel-card" id="organizers"><span class="section-kicker">FICTIONAL ORGANIZER RECORD</span><h2>Manage demo organizers</h2><div class="admin-user-row"><span class="profile-avatar avatar-orange">SO</span><span><strong>Sample Organizer</strong><small data-organizer-demo-status>Fictional · local demo account</small></span><button type="button" class="button button-outline button-small" data-suspend-demo>Suspend demo account</button></div><p class="table-footnote">Status changes persist only in this browser. No real organizer accounts exist.</p></article><article class="panel-card" id="categories"><span class="section-kicker">EVENT TAXONOMY</span><h2>Sample categories</h2><div class="admin-category-list">${DATA.categories.map((category) => `<span>${escapeHTML(category.name)} <small>${category.count} demo events</small></span>`).join("")}</div></article></section><section class="panel-card data-table-panel" id="bookings"><div class="panel-title"><div><span class="section-kicker">LOCAL SIMULATIONS</span><h2>Recent demo bookings</h2></div><a class="text-link" href="/Dashboard/Bookings">Attendee bookings ${icon("arrow-up-right")}</a></div><div class="admin-booking-list">${
      bookings().length
        ? bookings()
            .slice(0, 5)
            .map(
              (booking) =>
                `<div class="admin-booking-row"><strong>${escapeHTML(booking.eventTitle)}</strong><span>${escapeHTML(booking.reference)}</span><span>${escapeHTML(booking.status || "Upcoming")} · demo</span><strong>${money(booking.total)}</strong></div>`,
            )
            .join("")
        : '<p class="table-footnote">No local demo bookings yet. Try the sample checkout to see one here.</p>'
    }</div><p class="table-footnote">Booking details are stored in this browser only; totals are not revenue.</p></section><section class="panel-card admin-settings-panel" id="settings"><div><span class="section-kicker">DEMO SETTINGS</span><h2>Reset the local experience</h2><p class="table-footnote">Clear favorites, simulated bookings, profile edits, organizer listings, and moderation changes on this browser.</p></div><div class="admin-settings-actions"><button class="button button-outline" type="button" data-reset-demo>${icon("rotate-ccw")} Reset demo data</button><a class="button button-outline" href="/Home/Privacy">Privacy &amp; demo terms</a></div></section>`;
    populateSelect(
      $("[data-admin-category]"),
      DATA.categories.map((item) => item.name),
      "All categories",
    );
    const pageSize = 8;
    let pageIndex = 0;
    const draw = () => {
      const query = $("[data-admin-search]").value.toLowerCase();
      const category = $("[data-admin-category]").value;
      const status = $("[data-admin-status]").value;
      const sort = $("[data-admin-sort]").value;
      let rows = events.filter(
        (item) =>
          (!query ||
            `${item.title} ${item.location}`.toLowerCase().includes(query)) &&
          (!category || item.category === category) &&
          (!status || (mod[item.id] || "pending") === status),
      );
      if (sort === "price") rows.sort((a, b) => a.price - b.price);
      if (sort === "date") rows.sort((a, b) => a.date.localeCompare(b.date));
      if (sort === "name") rows.sort((a, b) => a.title.localeCompare(b.title));
      const pageCount = Math.max(1, Math.ceil(rows.length / pageSize));
      pageIndex = Math.min(pageIndex, pageCount - 1);
      const visible = rows.slice(
        pageIndex * pageSize,
        (pageIndex + 1) * pageSize,
      );
      const tbody = $("[data-admin-rows]");
      tbody.innerHTML =
        visible
          .map((item) => {
            const state = mod[item.id] || "pending";
            return `<tr><td><div class="table-event-cell"><img src="${safeURL(item.image || DATA.imageFallback)}" alt=""/><span><strong>${escapeHTML(item.title)}</strong><small>${escapeHTML(item.category)} · demo</small></span></div></td><td>${formatDate(item.date)}</td><td>${escapeHTML(item.location)}</td><td>${money(item.price)}</td><td><span class="status-pill status-${state}">${state === "approved" ? "Approved · demo" : state === "rejected" ? "Rejected · demo" : "Pending · demo"}</span></td><td><div class="table-actions admin-actions"><button type="button" data-review="approved" data-event-id="${escapeHTML(item.id)}" aria-label="Approve demo event">${icon("check")}</button><button type="button" data-review="rejected" data-event-id="${escapeHTML(item.id)}" aria-label="Reject demo event">${icon("x")}</button><a href="/Events/Details/${encodeURIComponent(item.id)}" aria-label="View demo event">${icon("eye")}</a><button type="button" data-admin-edit="${escapeHTML(item.id)}" aria-label="Edit demo event">${icon("pencil")}</button><button type="button" data-admin-delete="${escapeHTML(item.id)}" aria-label="Delete demo event">${icon("trash-2")}</button></div></td></tr>`;
          })
          .join("") ||
        '<tr><td colspan="6"><div class="table-empty">No matching demo events.</div></td></tr>';
      const pager = $("[data-admin-pagination]");
      pager.innerHTML = rows.length
        ? `<span>Showing ${pageIndex * pageSize + 1}–${Math.min((pageIndex + 1) * pageSize, rows.length)} of ${rows.length} sample events</span><div><button class="button button-outline button-small" type="button" data-admin-page="-1" ${pageIndex === 0 ? "disabled" : ""}>Previous</button><span>Page ${pageIndex + 1} of ${pageCount}</span><button class="button button-outline button-small" type="button" data-admin-page="1" ${pageIndex >= pageCount - 1 ? "disabled" : ""}>Next</button></div>`
        : "";
      pager
        .querySelector('[data-admin-page="-1"]')
        ?.addEventListener("click", () => {
          pageIndex--;
          draw();
        });
      pager
        .querySelector('[data-admin-page="1"]')
        ?.addEventListener("click", () => {
          pageIndex++;
          draw();
        });
      rerenderIcons();
    };
    $("[data-admin-search]").addEventListener("input", () => {
      pageIndex = 0;
      draw();
    });
    [
      "[data-admin-category]",
      "[data-admin-status]",
      "[data-admin-sort]",
    ].forEach((selector) =>
      $(selector).addEventListener("change", () => {
        pageIndex = 0;
        draw();
      }),
    );
    draw();
    updateAdminSuspensionUI();
  }
  function updateAdminSuspensionUI() {
    const suspended = read(KEYS.organizerSuspension, false);
    $$("[data-suspend-demo]").forEach((button) => {
      button.textContent = suspended
        ? "Restore demo account"
        : "Suspend demo account";
      button.setAttribute("aria-pressed", String(suspended));
    });
    $$("[data-organizer-demo-status]").forEach((label, index) => {
      label.textContent = suspended
        ? index === 0
          ? "Organizer · suspended (demo)"
          : "Fictional · suspended locally"
        : index === 0
          ? "Organizer · fictional"
          : "Fictional · local demo account";
    });
  }
  function adminEventEditModal(record) {
    showModal(
      `<span class="modal-icon">${icon("pencil")}</span><span class="section-kicker">LOCAL MODERATION EDIT</span><h2 id="modal-title">Edit demo event</h2><form data-admin-edit-form><label class="form-field"><span>Event title</span><input name="title" value="${escapeHTML(record.title)}" required/></label><label class="form-field"><span>Category</span><select name="category" required>${DATA.categories.map((category) => `<option value="${escapeHTML(category.name)}" ${category.name === record.category ? "selected" : ""}>${escapeHTML(category.name)}</option>`).join("")}</select></label><label class="form-field"><span>Location</span><input name="location" value="${escapeHTML(record.location)}" required/></label><label class="form-field"><span>Sample ticket price (₱)</span><input name="price" type="number" min="0" step="50" value="${Number(record.price || 0)}" required/></label><div class="modal-actions"><button type="button" class="button button-outline" data-modal-close>Cancel</button><button type="submit" class="button button-primary">Save demo changes</button></div></form><p class="form-footnote">Only the local sample listing changes. No public event is modified.</p>`,
      (box) =>
        box
          .querySelector("[data-admin-edit-form]")
          .addEventListener("submit", (event) => {
            event.preventDefault();
            const form = event.currentTarget;
            if (!form.reportValidity()) return;
            const values = Object.fromEntries(new FormData(form));
            updateEventRecord(record, values);
            closeModal();
            renderAdmin();
            toast("Demo event updated in this browser.");
          }),
    );
  }
  function initAdmin() {
    if (!$("[data-admin-sidebar]")) return;
    fillSidebars();
    renderAdmin();
    document.addEventListener("click", async (event) => {
      const review = event.target.closest("[data-review]");
      if (review) {
        const mod = read(KEYS.moderation, {});
        mod[review.dataset.eventId] = review.dataset.review;
        save(KEYS.moderation, mod);
        renderAdmin();
        toast(`Demo event ${review.dataset.review}.`);
      }
      const edit = event.target.closest("[data-admin-edit]");
      if (edit) {
        const record = findEvent(edit.dataset.adminEdit);
        if (record) adminEventEditModal(record);
      }
      const del = event.target.closest("[data-admin-delete]");
      if (del) {
        const yes = await confirmModal({
          title: "Delete this demo event?",
          text: "This removes the sample event from this browser only. No real listing is affected.",
          confirm: "Delete demo event",
          danger: true,
        });
        if (yes) {
          removeEventRecord(del.dataset.adminDelete);
          renderAdmin();
          toast("Sample event removed.");
        }
      }
      if (event.target.closest("[data-user-detail]"))
        showModal(
          `<span class="modal-icon">${icon("user-round")}</span><span class="section-kicker">SAMPLE ACCOUNT</span><h2 id="modal-title">${escapeHTML(profile().name)}</h2><p class="modal-copy">${escapeHTML(profile().email)}<br/>Attendee profile · stored locally for this demo only.</p><div class="modal-actions"><button class="button button-primary" type="button" data-modal-close>Close</button></div>`,
        );
      if (event.target.closest("[data-suspend-demo]")) {
        const suspended = read(KEYS.organizerSuspension, false);
        const yes = await confirmModal({
          title: suspended
            ? "Restore sample organizer?"
            : "Suspend sample organizer?",
          text: "This demo status changes only in the local interface; it does not affect real access or accounts.",
          confirm: suspended ? "Restore demo" : "Suspend demo",
        });
        if (yes) {
          save(KEYS.organizerSuspension, !suspended);
          updateAdminSuspensionUI();
          toast(
            suspended
              ? "Sample organizer restored in this browser."
              : "Sample organizer marked as suspended in this browser.",
          );
        }
      }
      if (event.target.closest("[data-reset-demo]")) resetDemo();
    });
  }
  function initDashboardHashNavigation() {
    const sidebar = $("[data-admin-sidebar]") || $("[data-organizer-sidebar]");
    if (!sidebar) return;
    const sync = () => {
      const hash = location.hash;
      let matched = false;
      $$(".dashboard-nav [data-dashboard-link]", sidebar).forEach((link) => {
        const active =
          !!hash && new URL(link.href, location.href).hash === hash;
        link.classList.toggle("active", active);
        matched = matched || active;
      });
      if (!matched)
        $$('.dashboard-nav [data-dashboard-link="overview"]', sidebar).forEach(
          (link) => link.classList.add("active"),
        );
    };
    window.addEventListener("hashchange", sync);
    sync();
  }

  function resetDemo() {
    confirmModal({
      title: "Reset all Evently demo data?",
      text: "This clears local favorites, demo bookings, profile edits, organizer listings and studio settings, event overrides/removals, and moderation changes from this browser.",
      confirm: "Reset demo data",
      danger: true,
    }).then((yes) => {
      if (!yes) return;
      Object.values(KEYS).forEach((key) => localStorage.removeItem(key));
      toast("Demo data reset.");
      window.setTimeout(() => (location.href = "/"), 350);
    });
  }

  function initAuth() {
    const login = $("[data-login-form]");
    login?.addEventListener("submit", (event) => {
      event.preventDefault();
      const fields = $$("input[required]", login);
      if (!fields.map(validateField).every(Boolean)) return;
      const email = login.elements.email.value.trim();
      const existing = profile();
      save(KEYS.profile, { ...existing, email });
      toast("Demo sign-in complete. No password was saved.");
      window.setTimeout(() => (location.href = "/Dashboard"), 400);
    });
    const register = $("[data-register-form]");
    register?.addEventListener("submit", (event) => {
      event.preventDefault();
      const fields = $$("input[required]", register);
      let valid = fields.map((input) => validateField(input)).every(Boolean);
      if (register.elements.password.value.length < 8) {
        const passwordError = register.elements.password
          .closest(".form-field")
          ?.querySelector(".field-error");
        if (passwordError)
          passwordError.textContent =
            "Use at least 8 characters for this temporary demo field.";
        valid = false;
      }
      if (
        register.elements.password.value !==
        register.elements.confirmPassword.value
      ) {
        const confirmPasswordError = register.elements.confirmPassword
          .closest(".form-field")
          ?.querySelector(".field-error");
        if (confirmPasswordError)
          confirmPasswordError.textContent = "These passwords do not match.";
        valid = false;
      }
      if (!valid) return;
      const demoProfile = {
        name: register.elements.fullName.value.trim(),
        email: register.elements.email.value.trim(),
        mobile: register.elements.mobile.value.trim(),
        city: "Quezon City",
        accountType: register.elements.accountType.value,
        avatar: register.elements.fullName.value
          .split(" ")
          .map((w) => w[0])
          .slice(0, 2)
          .join("")
          .toUpperCase(),
      };
      save(KEYS.profile, demoProfile);
      toast("Sample profile created. Password fields were discarded.");
      window.setTimeout(
        () =>
          (location.href =
            demoProfile.accountType === "organizer"
              ? "/Organizer"
              : "/Dashboard"),
        400,
      );
    });
    const forgot = $("[data-forgot-form]");
    forgot?.addEventListener("submit", (event) => {
      event.preventDefault();
      if (!validateField(forgot.elements.email)) return;
      showModal(
        `<span class="modal-icon">${icon("mail-check")}</span><span class="section-kicker">SIMULATED FEEDBACK</span><h2 id="modal-title">You’re all set.</h2><p class="modal-copy">If this were a live service, reset instructions would be sent to ${escapeHTML(forgot.elements.email.value)}. No email was sent and no password was changed.</p><div class="modal-actions"><a class="button button-primary" href="/Account/Login">Back to log in</a></div>`,
      );
    });
    $$("[data-password-toggle]").forEach((button) =>
      button.addEventListener("click", () => {
        const input = button.closest(".password-input").querySelector("input");
        const visible = input.type === "password";
        input.type = visible ? "text" : "password";
        button.setAttribute(
          "aria-label",
          visible ? "Hide password" : "Show password",
        );
        button.innerHTML = icon(visible ? "eye-off" : "eye");
        rerenderIcons();
      }),
    );
  }
  function initGlobalClicks() {
    document.addEventListener("click", (event) => {
      const favorite = event.target.closest("[data-favorite]");
      if (favorite) {
        event.preventDefault();
        event.stopPropagation();
        toggleFavorite(favorite.dataset.favorite);
      }
      if (event.target.closest("[data-download-ticket]")) {
        const booking = currentSuccessBooking || read(KEYS.last, null);
        if (booking) downloadTicket(booking);
      }
    });
  }

  document.addEventListener("DOMContentLoaded", () => {
    initHeader();
    initGlobalModal();
    initGlobalClicks();
    if ($('[data-page="home"]')) initHome();
    if ($('[data-page="explore"]')) initExplore();
    if ($('[data-page="details"]')) initDetails();
    if ($('[data-page="checkout"]')) initCheckout();
    if ($('[data-page="success"]')) renderSuccess();
    initAttendee();
    initBookingCancellations();
    initOrganizer();
    initCreateEvent();
    initAdmin();
    initDashboardHashNavigation();
    initAuth();
    rerenderIcons();
  });
})();
