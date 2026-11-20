import { useState } from "react";
import { Download, Eye, Search, UserRound } from "lucide-react";
import { useApp } from "../../lib/app-context";
import { usePath } from "../../lib/router";
import { downloadCsv, formatDate } from "../../lib/utils";
import type { Attendee, Registration } from "../../types";
import {
  Badge,
  Button,
  EmptyState,
  Modal,
  PageTitle,
} from "../../components/ui";

const statusTone = (status: string): "green" | "amber" | "red" | "slate" =>
  status === "confirmed" || status === "Active"
    ? "green"
    : status === "pending"
      ? "amber"
      : status === "rejected"
        ? "red"
        : "slate";

function RegistrationManagement() {
  const { registrations, setRegistrations, events, notify } = useApp();
  const [search, setSearch] = useState("");
  const [status, setStatus] = useState("all");
  const [selected, setSelected] = useState<Registration | null>(null);
  const filtered = registrations.filter(
    (item) =>
      `${item.attendeeName} ${item.email} ${item.reference} ${events.find((event) => event.id === item.eventId)?.title ?? ""}`
        .toLowerCase()
        .includes(search.toLowerCase()) &&
      (status === "all" || item.status === status),
  );
  const updateStatus = (item: Registration, next: Registration["status"]) => {
    setRegistrations((current) =>
      current.map((registration) =>
        registration.id === item.id
          ? { ...registration, status: next }
          : registration,
      ),
    );
    notify(`Registration marked ${next}.`);
  };
  const exportCsv = () => {
    downloadCsv("evently-registrations.csv", [
      [
        "Attendee Name",
        "Email",
        "Event",
        "Registration Date",
        "Reference",
        "Payment Status",
        "Registration Status",
      ],
      ...filtered.map((item) => [
        item.attendeeName,
        item.email,
        events.find((event) => event.id === item.eventId)?.title ??
          "Event removed",
        item.registrationDate,
        item.reference,
        item.paymentStatus,
        item.status,
      ]),
    ]);
    notify("Registrations exported as CSV.");
  };
  return (
    <>
      <PageTitle
        eyebrow="THE GUEST LIST"
        title="Registrations."
        description="A clear picture of who’s coming and where things stand."
        action={
          <Button
            variant="secondary"
            onClick={exportCsv}
            icon={<Download size={15} />}
          >
            Export CSV
          </Button>
        }
      />
      <div className="table-toolbar">
        <div className="table-search">
          <Search size={16} />
          <input
            aria-label="Search registrations"
            value={search}
            onChange={(event) => setSearch(event.target.value)}
            placeholder="Find a guest, event, or reference..."
          />
        </div>
        <div className="table-filters">
          <select
            aria-label="Filter registration status"
            value={status}
            onChange={(event) => setStatus(event.target.value)}
          >
            <option value="all">All statuses</option>
            <option value="confirmed">Confirmed</option>
            <option value="pending">Pending</option>
            <option value="cancelled">Cancelled</option>
            <option value="rejected">Rejected</option>
          </select>
        </div>
      </div>
      <section className="dashboard-panel table-panel">
        <div className="table-scroll">
          <table className="data-table registration-data-table">
            <thead>
              <tr>
                <th>Attendee</th>
                <th>Event</th>
                <th>Registered</th>
                <th>Reference</th>
                <th>Payment</th>
                <th>Status</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {filtered.map((item) => {
                const related = events.find(
                  (event) => event.id === item.eventId,
                );
                return (
                  <tr key={item.id}>
                    <td>
                      <div className="table-person-cell">
                        <span className="avatar avatar-purple">
                          {item.attendeeName
                            .split(" ")
                            .map((part) => part[0])
                            .slice(0, 2)
                            .join("")}
                        </span>
                        <div>
                          <strong>{item.attendeeName}</strong>
                          <small>{item.email}</small>
                        </div>
                      </div>
                    </td>
                    <td>{related?.title ?? "Event removed"}</td>
                    <td>
                      {formatDate(item.registrationDate, {
                        month: "short",
                        day: "numeric",
                      })}
                    </td>
                    <td>
                      <code className="reference-code">{item.reference}</code>
                    </td>
                    <td>
                      <Badge
                        tone={
                          item.paymentStatus === "Paid"
                            ? "green"
                            : item.paymentStatus === "Pending"
                              ? "amber"
                              : "slate"
                        }
                      >
                        {item.paymentStatus}
                      </Badge>
                    </td>
                    <td>
                      <Badge tone={statusTone(item.status)} dot>
                        {item.status}
                      </Badge>
                    </td>
                    <td>
                      <div className="table-actions">
                        <button
                          className="table-icon"
                          onClick={() => setSelected(item)}
                          aria-label={`View ${item.attendeeName} registration`}
                        >
                          <Eye size={15} />
                        </button>
                        {item.status === "pending" && (
                          <button
                            className="status-approve"
                            onClick={() => updateStatus(item, "confirmed")}
                          >
                            Approve
                          </button>
                        )}
                        {item.status === "pending" && (
                          <button
                            className="status-reject"
                            onClick={() => updateStatus(item, "rejected")}
                          >
                            Reject
                          </button>
                        )}
                        {item.status === "confirmed" && (
                          <button
                            className="status-cancel"
                            onClick={() => updateStatus(item, "cancelled")}
                          >
                            Cancel
                          </button>
                        )}
                      </div>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
          {filtered.length === 0 && (
            <EmptyState
              title="No registrations to show."
              description="Try a different search or status."
              action={
                <Button
                  variant="secondary"
                  size="sm"
                  onClick={() => {
                    setSearch("");
                    setStatus("all");
                  }}
                >
                  Reset filters
                </Button>
              }
            />
          )}
        </div>
        <div className="table-pagination">
          <span>
            {filtered.length} registration{filtered.length === 1 ? "" : "s"}
          </span>
          <span className="admin-simulation-note">
            Payment status is mock data
          </span>
        </div>
      </section>
      {selected && (
        <Modal
          title="Registration details"
          onClose={() => setSelected(null)}
          footer={
            <Button variant="secondary" onClick={() => setSelected(null)}>
              Close
            </Button>
          }
        >
          <div className="registration-detail-modal">
            <div>
              <span>ATTENDEE</span>
              <strong>{selected.attendeeName}</strong>
              <small>{selected.email}</small>
              <small>{selected.phone}</small>
            </div>
            <div>
              <span>EVENT</span>
              <strong>
                {events.find((event) => event.id === selected.eventId)?.title ??
                  "Event removed"}
              </strong>
              <small>
                {events.find((event) => event.id === selected.eventId)?.date &&
                  formatDate(
                    events.find((event) => event.id === selected.eventId)!.date,
                  )}
              </small>
            </div>
            <div className="detail-modal-grid">
              <div>
                <span>REFERENCE</span>
                <strong>{selected.reference}</strong>
              </div>
              <div>
                <span>REGISTERED</span>
                <strong>{formatDate(selected.registrationDate)}</strong>
              </div>
              <div>
                <span>ATTENDEES</span>
                <strong>{selected.attendees}</strong>
              </div>
              <div>
                <span>STATUS</span>
                <Badge tone={statusTone(selected.status)}>
                  {selected.status}
                </Badge>
              </div>
            </div>
            {selected.organization && (
              <p>
                <strong>Organization:</strong> {selected.organization}
              </p>
            )}
            {selected.requirements && (
              <p>
                <strong>Special requirements:</strong> {selected.requirements}
              </p>
            )}
            <p className="simulation-note">
              This is demonstration data stored in your browser.
            </p>
          </div>
        </Modal>
      )}
    </>
  );
}

function AttendeeDirectory() {
  const { attendees, registrations, setAttendees, notify, events } = useApp();
  const [search, setSearch] = useState("");
  const [status, setStatus] = useState("all");
  const [selected, setSelected] = useState<Attendee | null>(null);
  const filtered = attendees.filter(
    (item) =>
      `${item.name} ${item.email} ${item.organization}`
        .toLowerCase()
        .includes(search.toLowerCase()) &&
      (status === "all" || item.status === status),
  );
  const history = selected
    ? registrations.filter(
        (item) => item.email.toLowerCase() === selected.email.toLowerCase(),
      )
    : [];
  const toggleStatus = (item: Attendee) => {
    const next = item.status === "Active" ? "Inactive" : "Active";
    setAttendees((current) =>
      current.map((attendee) =>
        attendee.id === item.id ? { ...attendee, status: next } : attendee,
      ),
    );
    notify(`${item.name} marked ${next.toLowerCase()}.`);
  };
  return (
    <>
      <PageTitle
        eyebrow="THE PEOPLE IN THE ROOM"
        title="Attendees."
        description="Get to know the community showing up."
        action={
          <span className="people-count">
            <UserRound size={15} />
            {attendees.length} people
          </span>
        }
      />
      <div className="table-toolbar">
        <div className="table-search">
          <Search size={16} />
          <input
            aria-label="Search attendees"
            value={search}
            onChange={(event) => setSearch(event.target.value)}
            placeholder="Search name, email or organization..."
          />
        </div>
        <div className="table-filters">
          <select
            aria-label="Filter attendee status"
            value={status}
            onChange={(event) => setStatus(event.target.value)}
          >
            <option value="all">Everyone</option>
            <option value="Active">Active</option>
            <option value="Inactive">Inactive</option>
          </select>
        </div>
      </div>
      <section className="dashboard-panel table-panel">
        <div className="table-scroll">
          <table className="data-table">
            <thead>
              <tr>
                <th>Attendee</th>
                <th>Organization</th>
                <th>Joined</th>
                <th>Registrations</th>
                <th>Status</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              {filtered.map((item) => {
                const count = registrations.filter(
                  (registration) =>
                    registration.email.toLowerCase() ===
                    item.email.toLowerCase(),
                ).length;
                return (
                  <tr key={item.id}>
                    <td>
                      <div className="table-person-cell">
                        <span className="avatar avatar-peach">
                          {item.name
                            .split(" ")
                            .map((part) => part[0])
                            .slice(0, 2)
                            .join("")}
                        </span>
                        <div>
                          <strong>{item.name}</strong>
                          <small>{item.email}</small>
                        </div>
                      </div>
                    </td>
                    <td>{item.organization || "—"}</td>
                    <td>
                      {formatDate(item.joined, {
                        month: "short",
                        year: "numeric",
                      })}
                    </td>
                    <td>{count}</td>
                    <td>
                      <Badge tone={statusTone(item.status)} dot>
                        {item.status}
                      </Badge>
                    </td>
                    <td>
                      <div className="table-actions">
                        <button
                          className="table-icon"
                          onClick={() => setSelected(item)}
                          aria-label={`View ${item.name}`}
                        >
                          <Eye size={15} />
                        </button>
                        <button
                          className="quiet-action"
                          onClick={() => toggleStatus(item)}
                        >
                          {item.status === "Active" ? "Deactivate" : "Activate"}
                        </button>
                      </div>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
          {filtered.length === 0 && (
            <EmptyState
              title="No attendees found."
              description="Try a broader search or reset the status filter."
              action={
                <Button
                  variant="secondary"
                  size="sm"
                  onClick={() => {
                    setSearch("");
                    setStatus("all");
                  }}
                >
                  Reset
                </Button>
              }
            />
          )}
        </div>
        <div className="table-pagination">
          <span>
            Showing {filtered.length} of {attendees.length} attendees
          </span>
        </div>
      </section>
      {selected && (
        <Modal
          title="Attendee profile"
          onClose={() => setSelected(null)}
          footer={
            <Button variant="secondary" onClick={() => setSelected(null)}>
              Close
            </Button>
          }
        >
          <div className="attendee-detail-modal">
            <span className="avatar avatar-blue attendee-large-avatar">
              {selected.name
                .split(" ")
                .map((part) => part[0])
                .slice(0, 2)
                .join("")}
            </span>
            <h3>{selected.name}</h3>
            <p>{selected.email}</p>
            <div className="attendee-detail-facts">
              <span>
                <strong>Organization</strong>
                {selected.organization || "—"}
              </span>
              <span>
                <strong>Joined</strong>
                {formatDate(selected.joined)}
              </span>
              <span>
                <strong>Phone</strong>
                {selected.phone}
              </span>
              <span>
                <strong>Status</strong>
                <Badge tone={statusTone(selected.status)}>
                  {selected.status}
                </Badge>
              </span>
            </div>
            <h4>Registration history</h4>
            {history.length ? (
              history.map((item) => (
                <div className="attendee-history-row" key={item.id}>
                  <span>{item.reference}</span>
                  <strong>
                    {events.find((event) => event.id === item.eventId)?.title ??
                      "Event removed"}
                  </strong>
                  <Badge tone={statusTone(item.status)}>{item.status}</Badge>
                </div>
              ))
            ) : (
              <p className="profile-muted">No registrations yet.</p>
            )}
          </div>
        </Modal>
      )}
    </>
  );
}

export default function PeopleAdminPage() {
  const page = usePath().split("?")[0];
  return page === "/admin/attendees" ? (
    <AttendeeDirectory />
  ) : (
    <RegistrationManagement />
  );
}
