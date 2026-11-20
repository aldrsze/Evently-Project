import {
  ArrowRight,
  CalendarDays,
  CheckCircle2,
  Clock3,
  Ticket,
  UsersRound,
} from "lucide-react";
import { useState } from "react";
import {
  Area,
  AreaChart,
  Bar,
  BarChart,
  CartesianGrid,
  ResponsiveContainer,
  Tooltip,
  XAxis,
  YAxis,
} from "recharts";
import { useApp } from "../../lib/app-context";
import { Link } from "../../lib/router";
import { monthlyAnalytics } from "../../data/events";
import { formatDate, formatMoney } from "../../lib/utils";
import { Badge, PageTitle } from "../../components/ui";

export default function AdminOverview() {
  const [chartPeriod, setChartPeriod] = useState<"6-months" | "year">(
    "6-months",
  );
  const { events, registrations, attendees, adminSettings } = useApp();
  const upcomingEvents = events
    .filter((item) => item.status === "upcoming")
    .sort((a, b) => a.date.localeCompare(b.date));
  const completed = events.filter((item) => item.status === "completed").length;
  const active = events.filter(
    (item) => item.status !== "cancelled" && item.status !== "archived",
  ).length;
  const completionRate = active ? Math.round((completed / active) * 100) : 0;
  const draftEvents = events.filter((item) => item.status === "draft");
  const statusTone = (status: string): "green" | "amber" | "red" | "slate" =>
    status === "confirmed" ? "green" : status === "pending" ? "amber" : "slate";
  const stats = [
    {
      label: "Total events",
      value: events.length,
      delta: "Across all categories",
      icon: CalendarDays,
      tone: "blue",
    },
    {
      label: "Upcoming",
      value: upcomingEvents.length,
      delta: `${events.filter((item) => item.status === "draft").length} drafts in the wings`,
      icon: Clock3,
      tone: "purple",
    },
    {
      label: "Registrations",
      value: registrations.length.toLocaleString(),
      delta: "+18.4% this month",
      icon: Ticket,
      tone: "green",
    },
    {
      label: "Attendees",
      value: attendees.length.toLocaleString(),
      delta: "Across 4 partner organizers",
      icon: UsersRound,
      tone: "peach",
    },
  ];
  const bestEvents = [...events]
    .filter((item) => item.registrations)
    .sort((a, b) => b.registrations - a.registrations)
    .slice(0, 5)
    .map((item) => ({
      name: item.title.length > 20 ? `${item.title.slice(0, 19)}…` : item.title,
      registrations: item.registrations,
    }));
  const chartData =
    chartPeriod === "year"
      ? monthlyAnalytics.filter((item) => item.year === 2026)
      : monthlyAnalytics.slice(-6);
  return (
    <>
      <PageTitle
        eyebrow="THE BIG PICTURE"
        title="Good morning, organizer."
        description="A clear view of what’s happening across your events."
        action={
          <Link
            className="button button-primary button-md"
            to="/admin/events/new"
          >
            Create an event <ArrowRight size={15} />
          </Link>
        }
      />
      <div className="admin-stat-grid">
        {stats.map(({ label, value, delta, icon: Icon, tone }) => (
          <article className="stat-card admin-stat-card" key={label}>
            <div className="stat-card-top">
              <span className={`stat-icon stat-icon-${tone}`}>
                <Icon size={18} />
              </span>
              <span className="stat-period">THIS YEAR</span>
            </div>
            <strong className="admin-stat-value">{value}</strong>
            <span className="admin-stat-label">{label}</span>
            <span
              className={`stat-delta ${delta.startsWith("+") ? "delta-up" : ""}`}
            >
              {delta}
            </span>
          </article>
        ))}
      </div>
      {((adminSettings.newEvent && draftEvents.length > 0) ||
        adminSettings.weeklyDigest) && (
        <div className="admin-settings-notices">
          {adminSettings.newEvent && draftEvents.length > 0 && (
            <section className="admin-settings-notice draft-reminder">
              <span className="eyebrow">DRAFT REMINDER</span>
              <strong>
                {draftEvents.length} event{draftEvents.length === 1 ? "" : "s"}{" "}
                still in draft
              </strong>
              <Link to="/admin/events">
                Review drafts <ArrowRight size={13} />
              </Link>
            </section>
          )}
          {adminSettings.weeklyDigest && (
            <section className="admin-settings-notice weekly-summary">
              <span className="eyebrow">WEEKLY DEMO SUMMARY</span>
              <strong>
                {registrations.length} registrations · {upcomingEvents.length}{" "}
                upcoming events
              </strong>
              <span>Across {events.length} events in your workspace.</span>
            </section>
          )}
        </div>
      )}
      <div className="admin-chart-grid">
        <section className="dashboard-panel chart-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">REGISTRATION MOMENTUM</span>
              <h2>People are showing up.</h2>
            </div>
            <select
              className="chart-select"
              aria-label="Chart time period"
              value={chartPeriod}
              onChange={(event) =>
                setChartPeriod(event.target.value as "6-months" | "year")
              }
            >
              <option value="6-months">Last 6 months</option>
              <option value="year">This year</option>
            </select>
          </div>
          <div className="chart-legend">
            <span>
              <i className="legend-dot legend-blue" />
              Registrations
            </span>
            <span>
              <i className="legend-dot legend-mint" />
              Attendance
            </span>
          </div>
          <div className="chart-area">
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart
                data={chartData}
                margin={{ top: 10, right: 7, left: -19, bottom: 0 }}
              >
                <defs>
                  <linearGradient
                    id="registrationFill"
                    x1="0"
                    y1="0"
                    x2="0"
                    y2="1"
                  >
                    <stop offset="0%" stopColor="#2563eb" stopOpacity={0.18} />
                    <stop offset="100%" stopColor="#2563eb" stopOpacity={0} />
                  </linearGradient>
                </defs>
                <CartesianGrid stroke="#edf1f6" vertical={false} />
                <XAxis
                  dataKey="month"
                  tickLine={false}
                  axisLine={false}
                  tick={{ fill: "#8490a2", fontSize: 11 }}
                  dy={9}
                />
                <YAxis
                  tickLine={false}
                  axisLine={false}
                  tick={{ fill: "#8490a2", fontSize: 11 }}
                />
                <Tooltip
                  contentStyle={{
                    border: "1px solid #e7ebf1",
                    borderRadius: 10,
                    fontSize: 12,
                  }}
                />
                <Area
                  type="monotone"
                  dataKey="registrations"
                  stroke="#2563eb"
                  strokeWidth={2.5}
                  fill="url(#registrationFill)"
                />
                <Area
                  type="monotone"
                  dataKey="attendance"
                  stroke="#44ad8e"
                  strokeWidth={2}
                  fill="transparent"
                />
              </AreaChart>
            </ResponsiveContainer>
          </div>
        </section>
        <section className="dashboard-panel chart-panel performance-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">EVENT PERFORMANCE</span>
              <h2>Popular with the room.</h2>
            </div>
            <Link className="text-link" to="/admin/analytics">
              Reports <ArrowRight size={13} />
            </Link>
          </div>
          <div className="chart-area">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart
                data={bestEvents}
                layout="vertical"
                margin={{ top: 3, right: 12, left: 5, bottom: 0 }}
              >
                <CartesianGrid stroke="#edf1f6" horizontal={false} />
                <XAxis type="number" hide />
                <YAxis
                  type="category"
                  dataKey="name"
                  tickLine={false}
                  axisLine={false}
                  width={125}
                  tick={{ fill: "#65728a", fontSize: 11 }}
                />
                <Tooltip
                  cursor={{ fill: "#f7f9fc" }}
                  contentStyle={{
                    border: "1px solid #e7ebf1",
                    borderRadius: 10,
                    fontSize: 12,
                  }}
                />
                <Bar
                  dataKey="registrations"
                  fill="#8c78e6"
                  radius={[0, 5, 5, 0]}
                  barSize={14}
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </section>
      </div>
      <div className="admin-lower-grid">
        {adminSettings.registrations && (
          <section className="dashboard-panel recent-registrations-panel">
            <div className="panel-heading">
              <div>
                <span className="eyebrow">JUST JOINED</span>
                <h2>Recent registrations.</h2>
              </div>
              <Link className="text-link" to="/admin/registrations">
                All registrations <ArrowRight size={13} />
              </Link>
            </div>
            <div className="recent-registration-list">
              {registrations.slice(0, 5).map((item) => {
                const related = events.find(
                  (event) => event.id === item.eventId,
                );
                return (
                  <div className="recent-registration-row" key={item.id}>
                    <span className="avatar avatar-blue">
                      {item.attendeeName
                        .split(" ")
                        .map((part) => part[0])
                        .slice(0, 2)
                        .join("")}
                    </span>
                    <div>
                      <strong>{item.attendeeName}</strong>
                      <span>{related?.title ?? "Event registration"}</span>
                    </div>
                    <Badge tone={statusTone(item.status)}>{item.status}</Badge>
                    <small>
                      {formatDate(item.registrationDate, {
                        month: "short",
                        day: "numeric",
                      })}
                    </small>
                  </div>
                );
              })}
            </div>
          </section>
        )}
        <section className="dashboard-panel upcoming-admin-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">ON THE HORIZON</span>
              <h2>Coming up.</h2>
            </div>
            <Link className="text-link" to="/admin/events">
              Manage <ArrowRight size={13} />
            </Link>
          </div>
          {upcomingEvents.slice(0, 4).map((item) => (
            <Link
              to={`/events/${item.id}`}
              className="upcoming-admin-row"
              key={item.id}
            >
              <img src={item.image} alt="" />
              <span className="admin-date-block">
                <small>
                  {new Date(`${item.date}T12:00:00`)
                    .toLocaleString("en-US", { month: "short" })
                    .toUpperCase()}
                </small>
                <strong>{new Date(`${item.date}T12:00:00`).getDate()}</strong>
              </span>
              <div>
                <strong>{item.title}</strong>
                <span>
                  {item.registrations}/{item.capacity} registered ·{" "}
                  {formatMoney(item.price)}
                </span>
              </div>
              <ArrowRight size={14} />
            </Link>
          ))}
        </section>
      </div>
      <div className="admin-bottom-note">
        <CheckCircle2 size={16} />
        <span>Event completion rate</span>
        <strong>{completionRate}%</strong>
        <div className="completion-track">
          <span style={{ width: `${Math.max(completionRate, 8)}%` }} />
        </div>
        <span className="completion-copy">
          {completed} event{completed === 1 ? "" : "s"} completed of {active}{" "}
          active
        </span>
        <span className="admin-demo-tag">Demo analytics</span>
      </div>
    </>
  );
}
