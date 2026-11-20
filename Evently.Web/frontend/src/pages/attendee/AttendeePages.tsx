import { useMemo, useState, type FormEvent } from "react";
import {
  ArrowRight,
  Bell,
  CalendarDays,
  Check,
  Clock3,
  Heart,
  Pencil,
  Ticket,
  Trash2,
} from "lucide-react";
import { useApp } from "../../lib/app-context";
import { Link, usePath } from "../../lib/router";
import { formatDate, formatMoney } from "../../lib/utils";
import {
  Badge,
  Button,
  EmptyState,
  Field,
  Modal,
  PageTitle,
} from "../../components/ui";
import { EventCard } from "../../components/EventCard";
import { WorkspaceLayout } from "../../components/WorkspaceLayout";
import type { Registration } from "../../types";

function statusTone(status: string): "green" | "amber" | "red" | "slate" {
  if (status === "confirmed" || status === "Active") return "green";
  if (status === "pending") return "amber";
  if (status === "cancelled" || status === "Inactive") return "slate";
  return "red";
}

function AttendeeOverview() {
  const { events, registrations, savedEvents, profile } = useApp();
  const myRegistrations = registrations.filter(
    (item) =>
      item.email.toLowerCase() === profile.email.toLowerCase() ||
      item.attendeeName === profile.name,
  );
  const upcoming = myRegistrations.filter(
    (item) =>
      events.find((event) => event.id === item.eventId)?.status ===
        "upcoming" && item.status === "confirmed",
  );
  const nextEvent = upcoming
    .map((registration) =>
      events.find((item) => item.id === registration.eventId),
    )
    .find(Boolean);
  const statItems = [
    {
      label: "Total registrations",
      value: myRegistrations.length,
      icon: Ticket,
      tone: "blue",
    },
    {
      label: "Coming up",
      value: upcoming.length,
      icon: CalendarDays,
      tone: "purple",
    },
    {
      label: "Attended",
      value: myRegistrations.filter(
        (item) =>
          events.find((event) => event.id === item.eventId)?.status ===
          "completed",
      ).length,
      icon: Check,
      tone: "green",
    },
    {
      label: "Saved for later",
      value: savedEvents.length,
      icon: Heart,
      tone: "peach",
    },
  ];
  return (
    <>
      <PageTitle
        eyebrow="YOUR EVENTLY"
        title={`A little space for you, ${profile.name.split(" ")[0]}.`}
        description="Your plans, your people, all in one place."
        action={
          <Link className="button button-primary button-md" to="/events">
            Find an event <ArrowRight size={15} />
          </Link>
        }
      />
      <div className="stat-grid attendee-stat-grid">
        {statItems.map(({ label, value, icon: Icon, tone }) => (
          <article className="stat-card" key={label}>
            <span className={`stat-icon stat-icon-${tone}`}>
              <Icon size={18} />
            </span>
            <div>
              <strong>{value}</strong>
              <span>{label}</span>
            </div>
          </article>
        ))}
      </div>
      <div className="attendee-home-grid">
        <section className="dashboard-panel next-plan-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">NEXT ON YOUR CALENDAR</span>
              <h2>A plan to look forward to.</h2>
            </div>
            <Clock3 size={18} />
          </div>
          {nextEvent ? (
            <div className="next-plan-content">
              <img src={nextEvent.image} alt="" />
              <div>
                <span>
                  {formatDate(nextEvent.date, {
                    month: "long",
                    day: "numeric",
                  })}{" "}
                  · {nextEvent.startTime}
                </span>
                <h3>{nextEvent.title}</h3>
                <p>{nextEvent.location}</p>
                <Link className="text-link" to={`/events/${nextEvent.id}`}>
                  View event details <ArrowRight size={14} />
                </Link>
              </div>
            </div>
          ) : (
            <EmptyState
              title="Your calendar is open."
              description="Find a gathering that feels like you."
              action={
                <Link
                  className="button button-secondary button-sm"
                  to="/events"
                >
                  Explore events
                </Link>
              }
            />
          )}
        </section>
        <section className="dashboard-panel saved-preview-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">A SHORTLIST</span>
              <h2>Saved for later.</h2>
            </div>
            <Link className="text-link" to="/dashboard/saved">
              View all <ArrowRight size={13} />
            </Link>
          </div>
          {events
            .filter((item) => savedEvents.includes(item.id))
            .slice(0, 3)
            .map((event) => (
              <Link
                className="mini-saved-event"
                to={`/events/${event.id}`}
                key={event.id}
              >
                <img src={event.image} alt="" />
                <div>
                  <strong>{event.title}</strong>
                  <span>
                    {formatDate(event.date, { month: "short", day: "numeric" })}{" "}
                    · {event.location.split(",")[0]}
                  </span>
                </div>
                <ArrowRight size={15} />
              </Link>
            ))}
          {savedEvents.length === 0 && (
            <p className="panel-empty">
              Your saved list is waiting for something good.
            </p>
          )}
        </section>
      </div>
      <section className="dashboard-panel attendee-registration-preview">
        <div className="panel-heading">
          <div>
            <span className="eyebrow">RECENT ACTIVITY</span>
            <h2>Your registrations.</h2>
          </div>
          <Link className="text-link" to="/dashboard/registrations">
            See all <ArrowRight size={13} />
          </Link>
        </div>
        {myRegistrations.slice(0, 3).map((registration) => (
          <RegistrationRow
            key={registration.id}
            registration={registration}
            compact
          />
        ))}
        {myRegistrations.length === 0 && (
          <p className="panel-empty">
            No registrations yet. Find something to look forward to.
          </p>
        )}
      </section>
    </>
  );
}

function RegistrationRow({
  registration,
  compact = false,
}: {
  registration: Registration;
  compact?: boolean;
}) {
  const { events } = useApp();
  const event = events.find((item) => item.id === registration.eventId);
  if (!event) return null;
  return (
    <div
      className={`registration-row ${compact ? "registration-row-compact" : ""}`}
    >
      <img src={event.image} alt="" />
      <div className="registration-row-main">
        <Link to={`/events/${event.id}`}>
          <strong>{event.title}</strong>
        </Link>
        <span>
          {formatDate(event.date, {
            month: "short",
            day: "numeric",
            year: "numeric",
          })}{" "}
          · {event.location}
        </span>
      </div>
      <div className="registration-row-reference">
        <span>REFERENCE</span>
        <strong>{registration.reference}</strong>
      </div>
      <Badge tone={statusTone(registration.status)} dot>
        {registration.status}
      </Badge>
      {!compact && (
        <Link className="text-link" to={`/events/${event.id}`}>
          Details <ArrowRight size={13} />
        </Link>
      )}
    </div>
  );
}

function RegistrationsPage() {
  const { registrations, setRegistrations, profile, notify } = useApp();
  const [cancel, setCancel] = useState<Registration | null>(null);
  const myRegistrations = registrations.filter(
    (item) =>
      item.email.toLowerCase() === profile.email.toLowerCase() ||
      item.attendeeName === profile.name,
  );
  const confirmCancel = () => {
    if (!cancel) return;
    setRegistrations((current) =>
      current.map((item) =>
        item.id === cancel.id ? { ...item, status: "cancelled" } : item,
      ),
    );
    setCancel(null);
    notify("Your demo registration has been cancelled.");
  };
  return (
    <>
      <PageTitle
        eyebrow="YOUR PLANS"
        title="My registrations"
        description="Everything you’ve signed up for, in one place."
        action={
          <Link className="button button-primary button-md" to="/events">
            Find another event <ArrowRight size={15} />
          </Link>
        }
      />
      <section className="dashboard-panel registration-list-panel">
        {myRegistrations.length ? (
          myRegistrations.map((item) => (
            <div className="registration-manage-row" key={item.id}>
              <RegistrationRow registration={item} />
              <div className="registration-manage-actions">
                <span className="registration-type">
                  {formatMoney(
                    item.paymentStatus === "Free"
                      ? 0
                      : item.paymentStatus === "Paid"
                        ? 1
                        : 0,
                  )}
                  {item.paymentStatus === "Paid" && " · paid"}
                </span>
                {item.status !== "cancelled" && (
                  <button
                    className="quiet-action danger-action"
                    onClick={() => setCancel(item)}
                  >
                    <Trash2 size={14} />
                    Cancel
                  </button>
                )}
              </div>
            </div>
          ))
        ) : (
          <EmptyState
            title="Nothing on your calendar yet."
            description="Find something that catches your attention and save your place."
            action={
              <Link className="button button-primary button-md" to="/events">
                Explore events
              </Link>
            }
          />
        )}
      </section>
      {cancel && (
        <Modal
          title="Cancel this registration?"
          onClose={() => setCancel(null)}
          footer={
            <>
              <Button variant="secondary" onClick={() => setCancel(null)}>
                Keep my spot
              </Button>
              <Button className="button-danger" onClick={confirmCancel}>
                Cancel registration
              </Button>
            </>
          }
        >
          <p>
            Your demo registration for <strong>{cancel.attendeeName}</strong>{" "}
            will be marked as cancelled. This cannot be undone in the demo.
          </p>
        </Modal>
      )}
    </>
  );
}

function SavedPage() {
  const { events, savedEvents, setSavedEvents, notify } = useApp();
  const saved = events.filter((item) => savedEvents.includes(item.id));
  return (
    <>
      <PageTitle
        eyebrow="YOUR SHORTLIST"
        title="Saved for later."
        description="A few things you didn’t want to forget."
      />
      {saved.length ? (
        <div className="event-grid">
          {saved.map((item) => (
            <div className="saved-event-wrap" key={item.id}>
              <EventCard item={item} />
              <button
                className="saved-remove"
                onClick={() => {
                  setSavedEvents((current) =>
                    current.filter((id) => id !== item.id),
                  );
                  notify("Removed from your saved list.");
                }}
              >
                <Heart size={14} fill="currentColor" />
                Remove from saved
              </button>
            </div>
          ))}
        </div>
      ) : (
        <div className="dashboard-panel">
          <EmptyState
            icon={<Heart size={21} />}
            title="Your shortlist is a blank page."
            description="Save an event that feels right, and we’ll keep it here."
            action={
              <Link className="button button-primary button-md" to="/events">
                Explore events
              </Link>
            }
          />
        </div>
      )}
    </>
  );
}

function ProfilePage() {
  const { profile, setProfile, notify } = useApp();
  const [form, setForm] = useState(profile);
  const [passwordOpen, setPasswordOpen] = useState(false);
  const [passwords, setPasswords] = useState({
    current: "",
    next: "",
    confirm: "",
  });
  const [message, setMessage] = useState("");
  const update = (
    key: "name" | "email" | "phone" | "organization" | "title",
    value: string,
  ) => setForm((current) => ({ ...current, [key]: value }));
  const save = (event: FormEvent) => {
    event.preventDefault();
    if (!form.name.trim() || !form.email.includes("@")) {
      notify("Please add a valid name and email before saving.", "error");
      return;
    }
    setProfile(form);
    notify("Your profile updates are saved.");
  };
  const changePassword = (event: FormEvent) => {
    event.preventDefault();
    if (
      !passwords.current ||
      passwords.next.length < 6 ||
      passwords.next !== passwords.confirm
    ) {
      setMessage(
        "Enter your current password and confirm a new password of at least 6 characters.",
      );
      return;
    }
    setMessage("Password updated in this local demo only.");
    setPasswords({ current: "", next: "", confirm: "" });
  };
  return (
    <>
      <PageTitle
        eyebrow="YOUR DETAILS"
        title="Profile settings"
        description="A few small details help make your Evently feel like yours."
      />
      <div className="profile-layout">
        <form className="dashboard-panel profile-form" onSubmit={save}>
          <div className="panel-heading">
            <div>
              <span className="eyebrow">PERSONAL INFORMATION</span>
              <h2>Your details.</h2>
            </div>
            <span className="profile-avatar-large">
              {profile.name
                .split(" ")
                .map((part) => part[0])
                .slice(0, 2)
                .join("")}
            </span>
          </div>
          <div className="profile-fields">
            <Field
              label="Full name"
              name="profile-name"
              value={form.name}
              onChange={(event) => update("name", event.target.value)}
              requiredMark
            />
            <Field
              label="Email address"
              name="profile-email"
              type="email"
              value={form.email}
              onChange={(event) => update("email", event.target.value)}
              requiredMark
            />
            <Field
              label="Phone number"
              name="profile-phone"
              type="tel"
              value={form.phone}
              onChange={(event) => update("phone", event.target.value)}
            />
            <Field
              label="Organization or institution"
              name="profile-org"
              value={form.organization}
              onChange={(event) => update("organization", event.target.value)}
            />
            <Field
              label="A little about your role"
              name="profile-title"
              value={form.title}
              onChange={(event) => update("title", event.target.value)}
            />
          </div>
          <Button type="submit">
            Save changes <Check size={15} />
          </Button>
        </form>
        <div className="profile-side">
          <section className="dashboard-panel notification-panel">
            <div className="panel-heading">
              <div>
                <span className="eyebrow">STAY IN THE LOOP</span>
                <h2>Notifications.</h2>
              </div>
              <Bell size={17} />
            </div>
            {[
              {
                key: "eventUpdates",
                label: "Event updates",
                desc: "Changes to events you’ve registered for",
              },
              {
                key: "reminders",
                label: "Gentle reminders",
                desc: "A heads-up before an event begins",
              },
              {
                key: "newsletter",
                label: "The occasional good thing",
                desc: "A short note about what’s coming up",
              },
            ].map((item) => (
              <label className="preference-row" key={item.key}>
                <span>
                  <strong>{item.label}</strong>
                  <small>{item.desc}</small>
                </span>
                <input
                  type="checkbox"
                  checked={
                    form.notifications[
                      item.key as keyof typeof form.notifications
                    ]
                  }
                  onChange={(event) => {
                    const next = {
                      ...form,
                      notifications: {
                        ...form.notifications,
                        [item.key]: event.target.checked,
                      },
                    };
                    setForm(next);
                    setProfile(next);
                    notify("Notification preference updated.");
                  }}
                />
                <span className="toggle-track" />
              </label>
            ))}
          </section>
          <section className="dashboard-panel password-panel">
            <div className="panel-heading">
              <div>
                <span className="eyebrow">ACCOUNT SECURITY</span>
                <h2>Change password.</h2>
              </div>
              <button
                className="icon-button"
                onClick={() => setPasswordOpen((value) => !value)}
                aria-label="Toggle password form"
              >
                <Pencil size={16} />
              </button>
            </div>
            {passwordOpen ? (
              <form onSubmit={changePassword}>
                <Field
                  label="Current password"
                  name="current-password"
                  type="password"
                  value={passwords.current}
                  onChange={(event) =>
                    setPasswords((current) => ({
                      ...current,
                      current: event.target.value,
                    }))
                  }
                  requiredMark
                />
                <Field
                  label="New password"
                  name="new-password"
                  type="password"
                  value={passwords.next}
                  onChange={(event) =>
                    setPasswords((current) => ({
                      ...current,
                      next: event.target.value,
                    }))
                  }
                  requiredMark
                />
                <Field
                  label="Confirm new password"
                  name="confirm-password"
                  type="password"
                  value={passwords.confirm}
                  onChange={(event) =>
                    setPasswords((current) => ({
                      ...current,
                      confirm: event.target.value,
                    }))
                  }
                  requiredMark
                />
                <p className="simulation-note">
                  This mock form does not change a real password.
                </p>
                {message && <p className="field-helper">{message}</p>}
                <Button type="submit" size="sm">
                  Update password
                </Button>
              </form>
            ) : (
              <p className="profile-muted">
                Password updates are simulated and never sent to a server.
              </p>
            )}
          </section>
        </div>
      </div>
    </>
  );
}

export default function AttendeePage() {
  const path = usePath().split("?")[0];
  const page = useMemo(
    () =>
      path.endsWith("/registrations") ? (
        <RegistrationsPage />
      ) : path.endsWith("/saved") ? (
        <SavedPage />
      ) : path.endsWith("/profile") ? (
        <ProfilePage />
      ) : (
        <AttendeeOverview />
      ),
    [path],
  );
  return <WorkspaceLayout kind="attendee">{page}</WorkspaceLayout>;
}
