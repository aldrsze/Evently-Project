import {
  ArrowDownRight,
  ArrowRight,
  ArrowUpRight,
  CalendarCheck2,
  Compass,
  MapPin,
  Sparkles,
  Star,
  UsersRound,
} from "lucide-react";
import { useState } from "react";
import { categories, imageAssets } from "../../data/events";
import { useApp } from "../../lib/app-context";
import { Link, useNavigate } from "../../lib/router";
import { EventCard, EventGrid } from "../../components/EventCard";
import { Button } from "../../components/ui";

export default function HomePage() {
  const { events, categoryVisibility } = useApp();
  const navigate = useNavigate();
  const [search, setSearch] = useState("");
  const [location, setLocation] = useState("");
  const [category, setCategory] = useState("");
  const upcoming = events
    .filter((item) => item.status === "upcoming")
    .sort((a, b) => a.date.localeCompare(b.date));
  const featured = events
    .filter((item) => item.status === "upcoming")
    .slice(0, 3);
  const visibleCategories = categories.filter(
    (item) => categoryVisibility[item.name] !== false,
  );
  const submitSearch = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const params = new URLSearchParams();
    if (search) params.set("q", search);
    if (location) params.set("location", location);
    if (category) params.set("category", category);
    navigate(`/events${params.size ? `?${params.toString()}` : ""}`);
  };
  return (
    <>
      <section className="hero-section">
        <img
          className="hero-photo"
          src={imageAssets.hero}
          alt="People arriving at a thoughtfully hosted evening gathering"
        />
        <div className="hero-overlay" />
        <div className="hero-content page-container">
          <div className="hero-copy">
            <div className="hero-kicker">
              <span className="kicker-line" />A little more out of the ordinary
            </div>
            <h1>
              Discover Experiences.
              <br />
              <em>Create Unforgettable Moments.</em>
            </h1>
            <p>
              Find inspiring events, connect with communities, and experience
              moments worth remembering.
            </p>
            <div className="hero-ctas">
              <Link className="button button-primary button-lg" to="/events">
                Explore events <ArrowRight size={17} />
              </Link>
              <Link className="hero-secondary" to="/admin/events/new">
                Host an event <ArrowUpRight size={15} />
              </Link>
            </div>
          </div>
          <div className="hero-stamp">
            <span className="stamp-star">
              <Sparkles size={18} />
            </span>
            <span></span>
          </div>
          <form
            className="hero-search"
            onSubmit={submitSearch}
            aria-label="Find an event"
          >
            <div className="hero-search-field">
              <Compass size={18} />
              <label className="sr-only" htmlFor="hero-search-term">
                Search events
              </label>
              <input
                id="hero-search-term"
                value={search}
                onChange={(event) => setSearch(event.target.value)}
                placeholder="What would you like to experience?"
              />
            </div>
            <div className="hero-search-field hero-location-field">
              <MapPin size={17} />
              <label className="sr-only" htmlFor="hero-search-location">
                Location
              </label>
              <input
                id="hero-search-location"
                value={location}
                onChange={(event) => setLocation(event.target.value)}
                placeholder="City or anywhere"
              />
            </div>
            <div className="hero-search-field hero-category-field">
              <label className="sr-only" htmlFor="hero-search-category">
                Category
              </label>
              <select
                id="hero-search-category"
                value={category}
                onChange={(event) => setCategory(event.target.value)}
              >
                <option value="">Any kind of event</option>
                {visibleCategories.map((item) => (
                  <option key={item.name} value={item.name}>
                    {item.name}
                  </option>
                ))}
              </select>
            </div>
            <Button type="submit" className="hero-search-submit">
              Find an event <ArrowRight size={16} />
            </Button>
          </form>
        </div>
        <div className="hero-caption">
          <span>CURATED FOR THE CURIOUS</span>
          <span>01 / 04</span>
        </div>
      </section>

      <section className="section-wrap featured-section page-container">
        <div className="section-heading">
          <div>
            <span className="eyebrow">A good place to start</span>
            <h2>Worth stepping out for.</h2>
            <p>Some of the good things happening soon.</p>
          </div>
          <Link className="text-link" to="/events">
            See all events <ArrowUpRight size={15} />
          </Link>
        </div>
        <div className="featured-grid">
          {featured.map((item, index) => (
            <EventCard item={item} key={item.id} featured={index === 0} />
          ))}
        </div>
      </section>

      <section className="categories-section" id="categories">
        <div className="page-container">
          <div className="section-heading">
            <div>
              <span className="eyebrow">Find your kind of thing</span>
              <h2>What are you in the mood for?</h2>
              <p>From a room full of ideas to an evening that runs late.</p>
            </div>
            <Link className="text-link" to="/events">
              Browse everything <ArrowRight size={15} />
            </Link>
          </div>
          <div className="category-grid">
            {visibleCategories.map((item, index) => (
              <Link
                className={`category-tile category-${item.color}`}
                to={`/events?category=${encodeURIComponent(item.name)}`}
                key={item.name}
              >
                <div className="category-art">
                  <img src={item.image} alt="" loading="lazy" />
                  <span className="category-art-number">0{index + 1}</span>
                </div>
                <div className="category-tile-copy">
                  <div>
                    <h3>{item.name}</h3>
                    <p>{item.short}</p>
                  </div>
                  <span className="category-arrow">
                    <ArrowUpRight size={17} />
                  </span>
                </div>
              </Link>
            ))}
          </div>
        </div>
      </section>

      <section className="section-wrap page-container upcoming-section">
        <div className="section-heading">
          <div>
            <span className="eyebrow">Coming up</span>
            <h2>Plans worth making.</h2>
            <p>Room for spontaneity, with just enough notice.</p>
          </div>
          <Link className="text-link" to="/events">
            Explore the calendar <ArrowRight size={15} />
          </Link>
        </div>
        <EventGrid items={upcoming.slice(0, 3)} />
      </section>

      <section className="why-section">
        <div className="page-container why-layout">
          <div className="why-copy">
            <span className="eyebrow eyebrow-light">
              A more human way to go out
            </span>
            <h2>It starts with a good invitation.</h2>
            <p>
              We bring the details together so you can spend less time searching
              and more time showing up.
            </p>
            <Link className="button button-light button-md" to="/about">
              Get to know us <ArrowUpRight size={15} />
            </Link>
          </div>
          <div className="why-list">
            <article>
              <span className="why-icon">
                <Compass size={20} />
              </span>
              <div>
                <h3>Find the right room.</h3>
                <p>
                  A thoughtful edit, not an endless scroll. Discover experiences
                  that fit your interests and your city.
                </p>
              </div>
              <span className="why-number">01</span>
            </article>
            <article>
              <span className="why-icon">
                <CalendarCheck2 size={20} />
              </span>
              <div>
                <h3>Save a seat, simply.</h3>
                <p>
                  Clear dates, upfront pricing and a smooth way to go from
                  “maybe” to “see you there.”
                </p>
              </div>
              <span className="why-number">02</span>
            </article>
            <article>
              <span className="why-icon">
                <UsersRound size={20} />
              </span>
              <div>
                <h3>Make it yours.</h3>
                <p>
                  Join communities, meet the people behind the ideas, and bring
                  someone along.
                </p>
              </div>
              <span className="why-number">03</span>
            </article>
          </div>
        </div>
      </section>

      <section className="how-section page-container">
        <div className="section-heading">
          <div>
            <span className="eyebrow">Three easy steps</span>
            <h2>From curious to “I’m so glad I went.”</h2>
          </div>
        </div>
        <div className="how-grid">
          <article>
            <div className="how-num">
              01 <ArrowDownRight size={20} />
            </div>
            <div className="how-icon">
              <Compass size={23} />
            </div>
            <h3>Find something good.</h3>
            <p>
              Explore events by what you love, when you’re free, or where you’d
              like to go.
            </p>
          </article>
          <article>
            <div className="how-num">
              02 <ArrowDownRight size={20} />
            </div>
            <div className="how-icon">
              <CalendarCheck2 size={23} />
            </div>
            <h3>Save your spot.</h3>
            <p>
              A few details and you’re on the list. We’ll keep everything in one
              easy place.
            </p>
          </article>
          <article>
            <div className="how-num">
              03 <Star size={19} />
            </div>
            <div className="how-icon">
              <UsersRound size={23} />
            </div>
            <h3>Show up as you are.</h3>
            <p>
              Meet your people, learn something new, and leave with a story to
              tell.
            </p>
          </article>
        </div>
      </section>

      <section className="testimonials-section">
        <div className="page-container">
          <div className="section-heading">
            <div>
              <span className="eyebrow">Good company</span>
              <h2>A few kind words from the room.</h2>
            </div>
            <span className="demo-disclosure">Demo testimonials</span>
          </div>
          <div className="testimonial-grid">
            <article className="testimonial-card">
              <div className="testimonial-stars" aria-label="5 out of 5 stars">
                ★★★★★
              </div>
              <blockquote>
                “Found a workshop I didn’t know I needed. Came home with a new
                skill and three new friends.”
              </blockquote>
              <div className="testimonial-person">
                <span className="avatar avatar-purple">AT</span>
                <div>
                  <strong>Ava Thompson</strong>
                  <span>Designer & curious attendee</span>
                </div>
                <span className="demo-tag">DEMO</span>
              </div>
            </article>
            <article className="testimonial-card testimonial-highlight">
              <div className="testimonial-stars" aria-label="5 out of 5 stars">
                ★★★★★
              </div>
              <blockquote>
                “Our little community supper filled in a day. Evently made the
                whole thing feel easy, for us and our guests.”
              </blockquote>
              <div className="testimonial-person">
                <span className="avatar avatar-peach">NW</span>
                <div>
                  <strong>Noah Williams</strong>
                  <span>Community organizer</span>
                </div>
                <span className="demo-tag">DEMO</span>
              </div>
            </article>
            <article className="testimonial-card">
              <div className="testimonial-stars" aria-label="5 out of 5 stars">
                ★★★★★
              </div>
              <blockquote>
                “The event details were actually useful. I arrived knowing what
                to expect, and that made all the difference.”
              </blockquote>
              <div className="testimonial-person">
                <span className="avatar avatar-green">MC</span>
                <div>
                  <strong>Mia Chen</strong>
                  <span>Attendee & music lover</span>
                </div>
                <span className="demo-tag">DEMO</span>
              </div>
            </article>
          </div>
        </div>
      </section>

      <section className="home-cta page-container">
        <div className="home-cta-inner">
          <div>
            <span className="eyebrow eyebrow-light">
              The next good thing is out there
            </span>
            <h2>
              Your next unforgettable
              <br />
              experience starts here.
            </h2>
            <p>Pick a date. Find your people. Make a memory.</p>
          </div>
          <Link className="button button-light button-lg" to="/events">
            Explore upcoming events <ArrowRight size={17} />
          </Link>
          <span className="cta-scribble" aria-hidden="true">
            ✳
          </span>
        </div>
      </section>
    </>
  );
}
