import { ArrowUpRight, Bookmark, CalendarDays, MapPin } from "lucide-react";
import { useState } from "react";
import type { EventItem } from "../types";
import { formatMoney, formatShortDate, seatsLeft } from "../lib/utils";
import { useApp } from "../lib/app-context";
import { Link } from "../lib/router";
import { Badge } from "./ui";

export function EventCard({
  item,
  compact = false,
  featured = false,
}: {
  item: EventItem;
  compact?: boolean;
  featured?: boolean;
}) {
  const { savedEvents, setSavedEvents, notify } = useApp();
  const [imageError, setImageError] = useState(false);
  const date = formatShortDate(item.date);
  const saved = savedEvents.includes(item.id);
  const available = seatsLeft(item);
  const toggleSaved = () => {
    setSavedEvents((current) =>
      saved ? current.filter((id) => id !== item.id) : [...current, item.id],
    );
    notify(
      saved
        ? "Removed from your saved events."
        : "Saved for later. Good choice.",
    );
  };
  return (
    <article
      className={`event-card ${compact ? "event-card-compact" : ""} ${featured ? "event-card-featured" : ""}`}
    >
      <div className="event-card-inner">
        <div className="event-image-wrap">
          {!imageError && (
            <img
              className="event-image"
              src={item.image}
              alt={`${item.title} event`}
              loading="lazy"
              onError={() => setImageError(true)}
            />
          )}
          {imageError && (
            <div
              className={`event-image-fallback tone-${item.category.toLowerCase().split(/\W+/)[0]}`}
              aria-hidden="true"
            >
              <span>{item.category}</span>
            </div>
          )}
          <div className="event-image-top">
            <Badge tone="slate">{item.category}</Badge>
            <button
              className={`save-button ${saved ? "is-saved" : ""}`}
              onClick={toggleSaved}
              aria-label={
                saved
                  ? `Remove ${item.title} from saved events`
                  : `Save ${item.title}`
              }
              aria-pressed={saved}
            >
              <Bookmark size={16} fill={saved ? "currentColor" : "none"} />
            </button>
          </div>
          <div className="date-block">
            <span>{date.month}</span>
            <strong>{date.day}</strong>
          </div>
        </div>
        <div className="event-card-content">
          <div className="event-card-meta">
            <span>
              <CalendarDays size={14} />
              {date.weekday}, {item.startTime}
            </span>
            <Badge tone={item.price === 0 ? "green" : "blue"}>
              {formatMoney(item.price)}
            </Badge>
          </div>
          <h3>
            <Link to={`/events/${item.id}`}>{item.title}</Link>
          </h3>
          <p className="event-location">
            <MapPin size={14} />
            <span>{item.location}</span>
          </p>
          {!compact && <p className="event-summary">{item.description}</p>}
          <div className="event-card-foot">
            <span className="seats-note">
              {item.status === "completed"
                ? "Event complete"
                : item.status === "cancelled"
                  ? "Cancelled"
                  : available > 0
                    ? `${available} spots left`
                    : "Waitlist open"}
            </span>
            <Link
              className="event-link"
              to={`/events/${item.id}`}
              aria-label={`View details for ${item.title}`}
            >
              View details <ArrowUpRight size={15} />
            </Link>
          </div>
        </div>
      </div>
    </article>
  );
}

export function EventGrid({
  items,
  compact = false,
}: {
  items: EventItem[];
  compact?: boolean;
}) {
  return (
    <div className="event-grid">
      {items.map((item) => (
        <EventCard key={item.id} item={item} compact={compact} />
      ))}
    </div>
  );
}
