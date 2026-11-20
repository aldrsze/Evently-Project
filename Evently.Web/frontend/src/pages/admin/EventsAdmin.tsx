import { useMemo, useState, type FormEvent } from "react";
import {
  Archive,
  ArrowRight,
  CalendarPlus,
  Copy,
  Eye,
  FilePenLine,
  ImagePlus,
  MoreHorizontal,
  Plus,
  Search,
  Trash2,
  UploadCloud,
  X,
} from "lucide-react";
import { Link, useNavigate, usePath } from "../../lib/router";
import { useApp } from "../../lib/app-context";
import { categories, imageAssets } from "../../data/events";
import { compressImage } from "../../lib/storage";
import { emailIsValid, formatDate, formatMoney } from "../../lib/utils";
import type { EventItem } from "../../types";
import {
  Badge,
  Button,
  EmptyState,
  Field,
  Modal,
  PageTitle,
  SelectField,
  TextAreaField,
} from "../../components/ui";

const toneForStatus = (status: string): "green" | "amber" | "red" | "slate" =>
  status === "upcoming"
    ? "green"
    : status === "draft"
      ? "amber"
      : status === "cancelled"
        ? "red"
        : "slate";

export function EventsAdminPage() {
  const { events, setEvents, notify } = useApp();
  const navigate = useNavigate();
  const [search, setSearch] = useState("");
  const [status, setStatus] = useState("all");
  const [sort, setSort] = useState("soonest");
  const [page, setPage] = useState(1);
  const [remove, setRemove] = useState<EventItem | null>(null);
  const perPage = 6;
  const filtered = useMemo(() => {
    let list = events.filter((item) =>
      (item.title + item.category + item.location + item.organizer)
        .toLowerCase()
        .includes(search.toLowerCase()),
    );
    if (status !== "all") list = list.filter((item) => item.status === status);
    if (sort === "soonest")
      list = [...list].sort((a, b) => a.date.localeCompare(b.date));
    if (sort === "latest")
      list = [...list].sort((a, b) => b.date.localeCompare(a.date));
    if (sort === "registrations")
      list = [...list].sort((a, b) => b.registrations - a.registrations);
    return list;
  }, [events, search, status, sort]);
  const pages = Math.ceil(filtered.length / perPage);
  const rows = filtered.slice((page - 1) * perPage, page * perPage);
  const removeEvent = () => {
    if (!remove) return;
    setEvents((current) => current.filter((item) => item.id !== remove.id));
    notify(`“${remove.title}” was removed from your demo events.`);
    setRemove(null);
  };
  const duplicate = (item: EventItem) => {
    const copy = {
      ...item,
      id: `event-${Date.now()}`,
      title: `${item.title} (copy)`,
      status: "draft" as const,
      registrations: 0,
      featured: false,
      createdAt: new Date().toISOString().slice(0, 10),
    };
    setEvents((current) => [copy, ...current]);
    notify("A draft copy is ready to edit.");
  };
  const changeStatus = (item: EventItem, nextStatus: EventItem["status"]) => {
    setEvents((current) =>
      current.map((event) =>
        event.id === item.id ? { ...event, status: nextStatus } : event,
      ),
    );
    notify(
      nextStatus === "upcoming"
        ? "Your event is now published."
        : nextStatus === "archived"
          ? "Event archived."
          : "Event status updated.",
    );
  };
  return (
    <>
      <PageTitle
        eyebrow="MAKE A GOOD PLAN"
        title="Your events, together."
        description="Create, edit, and keep an eye on what’s coming up."
        action={
          <Link
            className="button button-primary button-md"
            to="/admin/events/new"
          >
            <Plus size={16} />
            Create event
          </Link>
        }
      />
      <div className="table-toolbar">
        <div className="table-search">
          <Search size={16} />
          <input
            aria-label="Search events"
            value={search}
            onChange={(event) => {
              setSearch(event.target.value);
              setPage(1);
            }}
            placeholder="Search events, venues, organizers..."
          />
        </div>
        <div className="table-filters">
          <select
            aria-label="Filter event status"
            value={status}
            onChange={(event) => {
              setStatus(event.target.value);
              setPage(1);
            }}
          >
            <option value="all">Every status</option>
            <option value="upcoming">Upcoming</option>
            <option value="draft">Draft</option>
            <option value="completed">Completed</option>
            <option value="cancelled">Cancelled</option>
            <option value="archived">Archived</option>
          </select>
          <select
            aria-label="Sort events"
            value={sort}
            onChange={(event) => setSort(event.target.value)}
          >
            <option value="soonest">Soonest date</option>
            <option value="latest">Latest date</option>
            <option value="registrations">Most registrations</option>
          </select>
        </div>
      </div>
      <section className="dashboard-panel table-panel">
        <div className="table-scroll">
          <table className="data-table">
            <thead>
              <tr>
                <th>Event</th>
                <th>Category</th>
                <th>Date</th>
                <th>Location</th>
                <th>Registrations</th>
                <th>Status</th>
                <th>
                  <span className="sr-only">Actions</span>
                </th>
              </tr>
            </thead>
            <tbody>
              {rows.map((item) => (
                <tr key={item.id}>
                  <td>
                    <div className="table-event-cell">
                      <img src={item.image} alt="" />
                      <div>
                        <Link to={`/events/${item.id}`}>{item.title}</Link>
                        <small>{item.organizer}</small>
                      </div>
                    </div>
                  </td>
                  <td>{item.category}</td>
                  <td>
                    {formatDate(item.date, {
                      month: "short",
                      day: "numeric",
                      year: "numeric",
                    })}
                  </td>
                  <td>{item.location}</td>
                  <td>
                    <span className="registration-count-cell">
                      {item.registrations}
                      <small> / {item.capacity || "—"}</small>
                    </span>
                  </td>
                  <td>
                    <Badge tone={toneForStatus(item.status)} dot>
                      {item.status}
                    </Badge>
                  </td>
                  <td>
                    <div className="table-actions">
                      <Link
                        className="table-icon"
                        to={`/events/${item.id}`}
                        aria-label={`View ${item.title}`}
                      >
                        <Eye size={16} />
                      </Link>
                      <button
                        className="table-icon"
                        aria-label={`Edit ${item.title}`}
                        onClick={() =>
                          navigate(`/admin/events/${item.id}/edit`)
                        }
                      >
                        <FilePenLine size={16} />
                      </button>
                      <details className="action-menu">
                        <summary aria-label={`More actions for ${item.title}`}>
                          <MoreHorizontal size={17} />
                        </summary>
                        <div className="action-menu-popover">
                          <button onClick={() => duplicate(item)}>
                            <Copy size={14} />
                            Duplicate
                          </button>
                          {item.status === "upcoming" ? (
                            <button
                              onClick={() => changeStatus(item, "archived")}
                            >
                              <Archive size={14} />
                              Archive
                            </button>
                          ) : (
                            <button
                              onClick={() => changeStatus(item, "upcoming")}
                            >
                              <CalendarPlus size={14} />
                              Publish
                            </button>
                          )}
                          <button
                            className="danger-menu-item"
                            onClick={() => setRemove(item)}
                          >
                            <Trash2 size={14} />
                            Delete
                          </button>
                        </div>
                      </details>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {rows.length === 0 && (
            <EmptyState
              title="Nothing matches that search."
              description="Try a different title or status filter."
              action={
                <Button
                  variant="secondary"
                  size="sm"
                  onClick={() => {
                    setSearch("");
                    setStatus("all");
                  }}
                >
                  Clear search
                </Button>
              }
            />
          )}
        </div>
        {filtered.length > 0 && (
          <div className="table-pagination">
            <span>
              Showing {Math.min((page - 1) * perPage + 1, filtered.length)}–
              {Math.min(page * perPage, filtered.length)} of {filtered.length}{" "}
              events
            </span>
            <div>
              <button
                disabled={page <= 1}
                onClick={() => setPage((value) => value - 1)}
                aria-label="Previous page"
              >
                ‹
              </button>
              <strong>
                {page} / {pages}
              </strong>
              <button
                disabled={page >= pages}
                onClick={() => setPage((value) => value + 1)}
                aria-label="Next page"
              >
                ›
              </button>
            </div>
          </div>
        )}
      </section>
      <div className="admin-simulation-note">
        All event changes are stored locally in this browser for demonstration.
      </div>
      {remove && (
        <Modal
          title="Delete this event?"
          onClose={() => setRemove(null)}
          footer={
            <>
              <Button variant="secondary" onClick={() => setRemove(null)}>
                Keep event
              </Button>
              <Button className="button-danger" onClick={removeEvent}>
                <Trash2 size={14} />
                Delete event
              </Button>
            </>
          }
        >
          <p>
            <strong>{remove.title}</strong> will be removed from your local
            demo. This action can’t be undone.
          </p>
        </Modal>
      )}
    </>
  );
}

interface EditorForm {
  title: string;
  description: string;
  category: string;
  date: string;
  endDate: string;
  startTime: string;
  endTime: string;
  venue: string;
  location: string;
  capacity: string;
  ticketType: string;
  price: string;
  deadline: string;
  organizer: string;
  organizerEmail: string;
  organizerPhone: string;
  coverImage: string;
  gallery: string[];
}
const emptyForm: EditorForm = {
  title: "",
  description: "",
  category: "",
  date: "",
  endDate: "",
  startTime: "09:00",
  endTime: "17:00",
  venue: "",
  location: "",
  capacity: "100",
  ticketType: "Free",
  price: "0",
  deadline: "",
  organizer: "Evently Studio",
  organizerEmail: "hello@evently.events",
  organizerPhone: "",
  coverImage: imageAssets.workshop,
  gallery: [],
};

function toInputTime(value: string): string {
  if (/^\d{2}:\d{2}$/.test(value)) return value;
  const match = /^(\d{1,2}):(\d{2})\s*(AM|PM)$/i.exec(value.trim());
  if (!match) return "";
  let hour = Number(match[1]) % 12;
  if (match[3].toUpperCase() === "PM") hour += 12;
  return `${String(hour).padStart(2, "0")}:${match[2]}`;
}

function toEventTime(value: string): string {
  const match = /^(\d{2}):(\d{2})$/.exec(value);
  if (!match) return value;
  const hour = Number(match[1]);
  const period = hour >= 12 ? "PM" : "AM";
  return `${String(hour % 12 || 12).padStart(2, "0")}:${match[2]} ${period}`;
}

export function EventEditorPage() {
  const { events, setEvents, notify } = useApp();
  const path = usePath().split("?")[0];
  const isEdit = path.includes("/edit");
  const editingId = isEdit ? path.split("/")[3] : undefined;
  const original = events.find((item) => item.id === editingId);
  const navigate = useNavigate();
  const [form, setForm] = useState<EditorForm>(() =>
    original
      ? {
          title: original.title,
          description: original.description,
          category: original.category,
          date: original.date,
          endDate: original.endDate ?? original.date,
          startTime: toInputTime(original.startTime),
          endTime: toInputTime(original.endTime),
          venue: original.venue,
          location: original.location,
          capacity: String(original.capacity),
          ticketType: original.ticketType,
          price: String(original.price),
          deadline: original.registrationDeadline ?? "",
          organizer: original.organizer,
          organizerEmail: original.organizerEmail,
          organizerPhone: original.organizerPhone,
          coverImage: original.image,
          gallery: original.gallery,
        }
      : emptyForm,
  );
  const [errors, setErrors] = useState<Record<string, string>>({});
  const [preview, setPreview] = useState(false);
  const [uploading, setUploading] = useState(false);
  const [submitState, setSubmitState] = useState<"draft" | "upcoming">("draft");
  const set = (key: keyof EditorForm, value: string | string[]) => {
    setForm((current) => ({ ...current, [key]: value }));
    setErrors((current) => ({ ...current, [key]: "" }));
  };
  const chooseCover = async (file?: File) => {
    if (!file) return;
    if (!file.type.startsWith("image/")) {
      setErrors((current) => ({
        ...current,
        coverImage: "Choose an image file.",
      }));
      return;
    }
    setUploading(true);
    try {
      set("coverImage", await compressImage(file));
    } catch {
      setErrors((current) => ({
        ...current,
        coverImage: "Could not prepare that image.",
      }));
    } finally {
      setUploading(false);
    }
  };
  const chooseGallery = async (files: FileList | null) => {
    if (!files?.length) return;
    setUploading(true);
    try {
      const images = await Promise.all(
        Array.from(files).slice(0, 4).map(compressImage),
      );
      set("gallery", [...form.gallery, ...images].slice(0, 4));
    } catch {
      notify("One of those gallery images could not be loaded.", "error");
    } finally {
      setUploading(false);
    }
  };
  const validate = () => {
    const next: Record<string, string> = {};
    if (!form.title.trim()) next.title = "Add an event title.";
    if (form.description.trim().length < 20)
      next.description = "Add a little more detail (20 characters minimum).";
    if (!form.category) next.category = "Choose a category.";
    if (!form.date) next.date = "Choose a start date.";
    const endDate = form.endDate || form.date;
    if (form.date && endDate < form.date)
      next.endDate = "End date cannot be before the start date.";
    if (!form.startTime) next.startTime = "Choose a start time.";
    if (!form.endTime) next.endTime = "Choose an end time.";
    if (
      form.date &&
      endDate === form.date &&
      form.startTime &&
      form.endTime &&
      form.endTime <= form.startTime
    )
      next.endTime = "End time must be after the start time.";
    if (!form.venue.trim()) next.venue = "Add a venue.";
    if (!form.location.trim()) next.location = "Add a city or location.";
    const capacity = Number(form.capacity);
    if (
      !Number.isInteger(capacity) ||
      capacity < Math.max(1, original?.registrations ?? 0)
    )
      next.capacity = `Capacity must be a whole number of at least ${Math.max(1, original?.registrations ?? 0)}.`;
    if (form.deadline && form.date && form.deadline > form.date)
      next.deadline = "Registration deadline cannot be after the event starts.";
    if (
      form.ticketType === "Paid" &&
      (!Number.isFinite(Number(form.price)) || Number(form.price) <= 0)
    )
      next.price = "Paid tickets need a price greater than zero.";
    if (!emailIsValid(form.organizerEmail))
      next.organizerEmail = "Enter a valid organizer email.";
    setErrors(next);
    return Object.keys(next).length === 0;
  };
  const save = (event: FormEvent, state: "draft" | "upcoming") => {
    event.preventDefault();
    if (!validate()) return;
    const item: EventItem = {
      id: original?.id ?? `custom-${Date.now()}`,
      title: form.title.trim(),
      description: form.description.trim(),
      category: form.category,
      date: form.date,
      endDate: form.endDate || form.date,
      startTime: toEventTime(form.startTime),
      endTime: toEventTime(form.endTime),
      venue: form.venue.trim(),
      location: form.location.trim(),
      address: `${form.venue.trim()}, ${form.location.trim()}`,
      capacity: Number(form.capacity),
      registrations: original?.registrations ?? 0,
      status: state,
      ticketType: form.ticketType as "Free" | "Paid",
      price: form.ticketType === "Free" ? 0 : Number(form.price),
      registrationDeadline: form.deadline,
      organizer: form.organizer.trim() || "Evently Studio",
      organizerEmail: form.organizerEmail.trim(),
      organizerPhone: form.organizerPhone.trim(),
      objectives: original?.objectives ?? [
        "Meet people who care about the same things",
        "Leave with practical ideas",
        "Make time for thoughtful conversation",
      ],
      agenda: original?.agenda ?? [
        {
          time: toEventTime(form.startTime),
          title: "Welcome & opening",
          detail: "Arrive, settle in, and meet your hosts.",
        },
        {
          time: form.endTime,
          title: "Closing conversation",
          detail: "A little space to reflect and connect.",
        },
      ],
      speakers: original?.speakers ?? [
        { name: "Your event host", role: form.organizer, initials: "EH" },
      ],
      image: form.coverImage || imageAssets.workshop,
      gallery: form.gallery.length
        ? form.gallery
        : [form.coverImage || imageAssets.workshop],
      featured: original?.featured,
      createdAt: original?.createdAt ?? new Date().toISOString().slice(0, 10),
    };
    setEvents((current) =>
      original
        ? current.map((eventItem) =>
            eventItem.id === original.id ? item : eventItem,
          )
        : [item, ...current],
    );
    notify(
      state === "upcoming"
        ? "Your event is published in the demo."
        : "Draft saved to this browser.",
    );
    navigate("/admin/events");
  };
  if (isEdit && !original)
    return (
      <EmptyState
        title="This event is no longer here."
        description="Head back to the event list to continue."
        action={
          <Link className="button button-primary button-md" to="/admin/events">
            Back to events
          </Link>
        }
      />
    );
  return (
    <>
      <PageTitle
        eyebrow={isEdit ? "TEND TO THE DETAILS" : "SOMETHING GOOD STARTS HERE"}
        title={isEdit ? "Edit your event." : "Create an event."}
        description="A few thoughtful details help the right people find their way in."
        action={
          isEdit ? (
            <Link
              className="button button-secondary button-md"
              to={`/events/${original?.id}`}
            >
              <Eye size={15} />
              Preview live page
            </Link>
          ) : undefined
        }
      />
      <form
        className="event-editor"
        onSubmit={(event) => save(event, submitState)}
        noValidate
      >
        <div className="editor-main-column">
          <section className="dashboard-panel editor-section">
            <div className="editor-section-heading">
              <span className="editor-section-index">01</span>
              <div>
                <h2>Basic information</h2>
                <p>Give people a reason to take a closer look.</p>
              </div>
            </div>
            <Field
              label="Event title"
              name="event-title"
              requiredMark
              value={form.title}
              onChange={(event) => set("title", event.target.value)}
              error={errors.title}
              placeholder="Something worth gathering for"
            />
            <TextAreaField
              label="Event description"
              requiredMark
              value={form.description}
              onChange={(event) => set("description", event.target.value)}
              rows={5}
              error={errors.description}
              placeholder="What makes this gathering special?"
              helper="A few clear, welcoming sentences go a long way."
            />
            <SelectField
              label="Category"
              value={form.category}
              requiredMark
              error={errors.category}
              onChange={(event) => set("category", event.target.value)}
              options={[
                { label: "Choose a category", value: "" },
                ...categories.map((item) => ({
                  label: item.name,
                  value: item.name,
                })),
              ]}
            />
            <div className="field-group">
              <div className="field-label-row">
                <label htmlFor="cover-image">Event cover image</label>
                {errors.coverImage && (
                  <span className="field-error">{errors.coverImage}</span>
                )}
              </div>
              <label className="image-upload" htmlFor="cover-image">
                <input
                  id="cover-image"
                  type="file"
                  accept="image/*"
                  onChange={(event) =>
                    void chooseCover(event.target.files?.[0])
                  }
                />
                <span className="upload-icon">
                  <UploadCloud size={20} />
                </span>
                <strong>
                  {uploading ? "Preparing your image…" : "Choose a cover image"}
                </strong>
                <small>
                  JPG, PNG or WebP. Compressed for local demo storage.
                </small>
              </label>
              {form.coverImage && (
                <div className="editor-image-preview">
                  <img src={form.coverImage} alt="Event cover preview" />
                  <button
                    type="button"
                    className="preview-remove"
                    onClick={() => set("coverImage", "")}
                    aria-label="Remove cover image"
                  >
                    <X size={14} />
                  </button>
                  <span>Cover image preview</span>
                </div>
              )}
            </div>
            <div className="field-group">
              <div className="field-label-row">
                <label htmlFor="gallery-images">Event gallery</label>
                <span className="field-helper-inline">Up to 4 images</span>
              </div>
              <label className="gallery-add" htmlFor="gallery-images">
                <ImagePlus size={17} />
                <span>Add gallery images</span>
                <input
                  id="gallery-images"
                  type="file"
                  accept="image/*"
                  multiple
                  onChange={(event) => void chooseGallery(event.target.files)}
                />
              </label>
              {form.gallery.length > 0 && (
                <div className="editor-gallery-preview">
                  {form.gallery.map((image, index) => (
                    <div key={`${index}-${image.slice(0, 30)}`}>
                      <img src={image} alt={`Gallery preview ${index + 1}`} />
                      <button
                        type="button"
                        onClick={() =>
                          set(
                            "gallery",
                            form.gallery.filter(
                              (_, itemIndex) => itemIndex !== index,
                            ),
                          )
                        }
                        aria-label={`Remove image ${index + 1}`}
                      >
                        <X size={12} />
                      </button>
                    </div>
                  ))}
                </div>
              )}
            </div>
          </section>
          <section className="dashboard-panel editor-section">
            <div className="editor-section-heading">
              <span className="editor-section-index">02</span>
              <div>
                <h2>Date and location</h2>
                <p>Clear details make it easy to say yes.</p>
              </div>
            </div>
            <div className="field-grid">
              <Field
                label="Start date"
                name="event-date"
                type="date"
                requiredMark
                value={form.date}
                onChange={(event) => set("date", event.target.value)}
                error={errors.date}
              />
              <Field
                label="End date"
                name="event-end-date"
                type="date"
                value={form.endDate}
                onChange={(event) => set("endDate", event.target.value)}
                error={errors.endDate}
              />
            </div>
            <div className="field-grid">
              <Field
                label="Start time"
                name="event-start-time"
                type="time"
                requiredMark
                value={form.startTime}
                onChange={(event) => set("startTime", event.target.value)}
                error={errors.startTime}
              />
              <Field
                label="End time"
                name="event-end-time"
                type="time"
                requiredMark
                value={form.endTime}
                onChange={(event) => set("endTime", event.target.value)}
                error={errors.endTime}
              />
            </div>
            <Field
              label="Venue"
              name="event-venue"
              requiredMark
              value={form.venue}
              onChange={(event) => set("venue", event.target.value)}
              error={errors.venue}
              placeholder="Name of the venue"
            />
            <Field
              label="Address / city"
              name="event-location"
              requiredMark
              value={form.location}
              onChange={(event) => set("location", event.target.value)}
              error={errors.location}
              placeholder="Manila, Philippines"
            />
          </section>
          <section className="dashboard-panel editor-section">
            <div className="editor-section-heading">
              <span className="editor-section-index">03</span>
              <div>
                <h2>Registration</h2>
                <p>Let people know what a spot includes.</p>
              </div>
            </div>
            <div className="field-grid">
              <Field
                label="Registration capacity"
                name="capacity"
                type="number"
                min="1"
                requiredMark
                value={form.capacity}
                onChange={(event) => set("capacity", event.target.value)}
                error={errors.capacity}
              />
              <SelectField
                label="Ticket type"
                value={form.ticketType}
                onChange={(event) => {
                  set("ticketType", event.target.value);
                  if (event.target.value === "Free") set("price", "0");
                }}
                options={[
                  { label: "Free event", value: "Free" },
                  { label: "Paid ticket", value: "Paid" },
                ]}
              />
            </div>
            {form.ticketType === "Paid" && (
              <Field
                label="Ticket price (PHP)"
                name="price"
                type="number"
                min="0"
                value={form.price}
                onChange={(event) => set("price", event.target.value)}
                error={errors.price}
                placeholder="1500"
              />
            )}
            <Field
              label="Registration deadline"
              name="deadline"
              type="date"
              value={form.deadline}
              onChange={(event) => set("deadline", event.target.value)}
              error={errors.deadline}
              helper="Optional. Leave blank to keep registration open until the event."
            />
          </section>
          <section className="dashboard-panel editor-section">
            <div className="editor-section-heading">
              <span className="editor-section-index">04</span>
              <div>
                <h2>Organizer information</h2>
                <p>Give attendees a friendly point of contact.</p>
              </div>
            </div>
            <Field
              label="Organizer name"
              name="organizer"
              value={form.organizer}
              onChange={(event) => set("organizer", event.target.value)}
            />
            <div className="field-grid">
              <Field
                label="Contact email"
                name="organizer-email"
                type="email"
                requiredMark
                value={form.organizerEmail}
                onChange={(event) => set("organizerEmail", event.target.value)}
                error={errors.organizerEmail}
              />
              <Field
                label="Contact number"
                name="organizer-phone"
                type="tel"
                value={form.organizerPhone}
                onChange={(event) => set("organizerPhone", event.target.value)}
              />
            </div>
          </section>
        </div>
        <aside className="editor-side-column">
          <section className="dashboard-panel publish-panel">
            <span className="eyebrow">MAKE IT OFFICIAL</span>
            <h2>Ready when you are.</h2>
            <p>
              Keep a draft while you’re working on the details, or publish when
              it’s ready for the world.
            </p>
            <div className="publish-status-row">
              <span className="publish-status-dot" />
              {isEdit
                ? `Current status: ${original?.status}`
                : "New event · not published"}
            </div>
            <Button
              type="submit"
              className="button-full"
              onClick={() => setSubmitState("upcoming")}
            >
              Publish event <ArrowRight size={15} />
            </Button>
            <Button
              type="button"
              variant="secondary"
              className="button-full"
              onClick={(event) => {
                setSubmitState("draft");
                save(event, "draft");
              }}
            >
              Save as draft
            </Button>
            <Button
              type="button"
              variant="tertiary"
              className="button-full"
              onClick={() => setPreview(true)}
            >
              <Eye size={15} />
              Preview event
            </Button>
          </section>
          <div className="editor-help-card">
            <span className="editor-help-icon">
              <ImagePlus size={18} />
            </span>
            <strong>Small details make a big difference.</strong>
            <p>
              Clear location, useful timing, and a warm description help guests
              picture themselves in the room.
            </p>
          </div>
          <p className="admin-simulation-note">
            Drafts, images and event edits are saved to local browser storage.
          </p>
        </aside>
      </form>
      {preview && (
        <Modal
          title="Event preview"
          onClose={() => setPreview(false)}
          footer={
            <Button variant="secondary" onClick={() => setPreview(false)}>
              Back to editing
            </Button>
          }
        >
          <div className="event-preview-modal">
            <img
              src={form.coverImage || imageAssets.workshop}
              alt="Event cover preview"
            />
            <span className="eyebrow">
              {form.category || "EVENT CATEGORY"} ·{" "}
              {form.location || "LOCATION"}
            </span>
            <h3>{form.title || "Your event title"}</h3>
            <p>
              {form.description ||
                "Your welcoming event description will appear here."}
            </p>
            <div>
              <strong>
                {form.date ? formatDate(form.date) : "Select a date"}
              </strong>
              <span>
                {form.venue || "Venue"} · {form.location || "City"}
              </span>
              <Badge tone={form.ticketType === "Free" ? "green" : "blue"}>
                {form.ticketType === "Free"
                  ? "Free"
                  : formatMoney(Number(form.price))}
              </Badge>
            </div>
            <p className="simulation-note">
              Preview only. Save or publish to add it to your local event list.
            </p>
          </div>
        </Modal>
      )}
    </>
  );
}
