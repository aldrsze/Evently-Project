import { useMemo, useState } from "react";
import {
  ArrowDownRight,
  ArrowUpRight,
  CalendarRange,
  Download,
  UsersRound,
} from "lucide-react";
import {
  Area,
  AreaChart,
  Bar,
  BarChart,
  CartesianGrid,
  Cell,
  Pie,
  PieChart,
  ResponsiveContainer,
  Tooltip,
  XAxis,
  YAxis,
} from "recharts";
import { useApp } from "../../lib/app-context";
import { categoryAnalytics, monthlyAnalytics } from "../../data/events";
import { downloadCsv, formatMoney } from "../../lib/utils";
import { Button, PageTitle } from "../../components/ui";

export default function ReportsAdmin() {
  const { events } = useApp();
  const [range, setRange] = useState("6m");
  const months =
    range === "3m"
      ? monthlyAnalytics.slice(-3)
      : range === "12m"
        ? monthlyAnalytics
        : monthlyAnalytics.slice(-6);
  const rangeLabel = months.length
    ? `${months[0].month.toUpperCase()} – ${months[months.length - 1].month.toUpperCase()}`
    : "";
  const eventPopularity = useMemo(
    () =>
      [...events]
        .filter((item) => item.registrations > 0)
        .sort((a, b) => b.registrations - a.registrations)
        .slice(0, 7)
        .map((item) => ({
          name:
            item.title.length > 24 ? `${item.title.slice(0, 23)}…` : item.title,
          count: item.registrations,
          revenue: item.registrations * item.price,
        })),
    [events],
  );
  const registeredCount = events.reduce(
    (total, item) => total + item.registrations,
    0,
  );
  const completedMonths = months.filter(
    (item) => item.attendance > 0 && item.registrations > 0,
  );
  const attendedCount = completedMonths.reduce(
    (total, item) => total + item.attendance,
    0,
  );
  const attendanceRegistered = completedMonths.reduce(
    (total, item) => total + item.registrations,
    0,
  );
  const attendanceRate = attendanceRegistered
    ? Math.round((attendedCount / attendanceRegistered) * 100)
    : 0;
  const paidRevenue = events.reduce(
    (total, item) => total + item.registrations * item.price,
    0,
  );
  const exportReport = () => {
    downloadCsv("evently-analytics.csv", [
      [
        "Event",
        "Category",
        "Date",
        "Registrations",
        "Capacity",
        "Ticket price",
        "Mock revenue",
      ],
      ...events.map((item) => [
        item.title,
        item.category,
        item.date,
        String(item.registrations),
        String(item.capacity),
        formatMoney(item.price),
        formatMoney(item.price * item.registrations),
      ]),
    ]);
  };
  return (
    <>
      <PageTitle
        eyebrow="A LOOK AT THE WHOLE ROOM"
        title="Reports & analytics."
        description="The patterns behind the good things you’re putting on."
        action={
          <Button
            variant="secondary"
            onClick={exportReport}
            icon={<Download size={15} />}
          >
            Download report
          </Button>
        }
      />
      <div className="analytics-range">
        <CalendarRange size={16} />
        <span>Showing</span>
        <select
          aria-label="Analytics date range"
          value={range}
          onChange={(event) => setRange(event.target.value)}
        >
          <option value="3m">Last 3 months</option>
          <option value="6m">Last 6 months</option>
          <option value="12m">Last 12 months</option>
        </select>
        <span className="analytics-range-note">
          All metrics are sample demonstration data.
        </span>
      </div>
      <div className="analytics-kpi-row">
        <article className="analytics-kpi">
          <span>REGISTRATIONS</span>
          <strong>{registeredCount.toLocaleString()}</strong>
          <small className="kpi-positive">
            <ArrowUpRight size={13} /> 18.4% vs. last period
          </small>
        </article>
        <article className="analytics-kpi">
          <span>ATTENDANCE RATE</span>
          <strong>{attendanceRate}%</strong>
          <small className="kpi-positive">
            <UsersRound size={13} /> {attendedCount.toLocaleString()} attended
            places in sample period
          </small>
        </article>
        <article className="analytics-kpi">
          <span>MOCK REVENUE</span>
          <strong>{formatMoney(paidRevenue)}</strong>
          <small>
            <ArrowDownRight size={13} /> Illustrative only
          </small>
        </article>
        <article className="analytics-kpi">
          <span>AVG. EVENT SIZE</span>
          <strong>
            {events.length ? Math.round(registeredCount / events.length) : 0}
          </strong>
          <small>Registrations per event</small>
        </article>
      </div>
      <div className="report-chart-grid">
        <section className="dashboard-panel report-panel report-large">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">REGISTRATION TRENDS</span>
              <h2>A steady room, month by month.</h2>
            </div>
            <span className="chart-chip">{rangeLabel}</span>
          </div>
          <div className="report-chart-area">
            <ResponsiveContainer width="100%" height="100%">
              <AreaChart
                data={months}
                margin={{ top: 10, right: 10, left: -18, bottom: 0 }}
              >
                <defs>
                  <linearGradient id="reportFill" x1="0" y1="0" x2="0" y2="1">
                    <stop offset="0%" stopColor="#2f6fee" stopOpacity={0.16} />
                    <stop offset="100%" stopColor="#2f6fee" stopOpacity={0} />
                  </linearGradient>
                </defs>
                <CartesianGrid stroke="#edf1f6" vertical={false} />
                <XAxis
                  dataKey="month"
                  tickLine={false}
                  axisLine={false}
                  tick={{ fill: "#8490a2", fontSize: 11 }}
                  dy={8}
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
                  dataKey="registrations"
                  type="monotone"
                  stroke="#2563eb"
                  strokeWidth={2.5}
                  fill="url(#reportFill)"
                />
                <Area
                  dataKey="attendance"
                  type="monotone"
                  stroke="#38a487"
                  strokeWidth={2}
                  fill="transparent"
                />
              </AreaChart>
            </ResponsiveContainer>
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
        </section>
        <section className="dashboard-panel report-panel popularity-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">EVENT POPULARITY</span>
              <h2>What people choose.</h2>
            </div>
          </div>
          <div className="report-chart-area">
            <ResponsiveContainer width="100%" height="100%">
              <BarChart
                data={eventPopularity}
                layout="vertical"
                margin={{ top: 3, right: 12, left: 4, bottom: 0 }}
              >
                <CartesianGrid stroke="#edf1f6" horizontal={false} />
                <XAxis type="number" hide />
                <YAxis
                  type="category"
                  dataKey="name"
                  tickLine={false}
                  axisLine={false}
                  width={135}
                  tick={{ fill: "#65728a", fontSize: 10 }}
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
                  dataKey="count"
                  fill="#8a72da"
                  radius={[0, 5, 5, 0]}
                  barSize={14}
                />
              </BarChart>
            </ResponsiveContainer>
          </div>
        </section>
        <section className="dashboard-panel report-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">BY CATEGORY</span>
              <h2>Different reasons to gather.</h2>
            </div>
          </div>
          <div className="category-pie-layout">
            <div className="pie-chart-wrap">
              <ResponsiveContainer width="100%" height="100%">
                <PieChart>
                  <Pie
                    data={categoryAnalytics}
                    dataKey="value"
                    nameKey="name"
                    innerRadius={54}
                    outerRadius={78}
                    paddingAngle={4}
                    stroke="none"
                  >
                    {categoryAnalytics.map((entry) => (
                      <Cell key={entry.name} fill={entry.color} />
                    ))}
                  </Pie>
                  <Tooltip
                    contentStyle={{
                      border: "1px solid #e7ebf1",
                      borderRadius: 10,
                      fontSize: 12,
                    }}
                  />
                </PieChart>
              </ResponsiveContainer>
            </div>
            <div className="pie-legend">
              {categoryAnalytics.map((item) => (
                <div key={item.name}>
                  <span style={{ background: item.color }} />
                  <span>{item.name}</span>
                  <strong>{item.value}%</strong>
                </div>
              ))}
            </div>
          </div>
        </section>
        <section className="dashboard-panel report-panel">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">ATTENDANCE</span>
              <h2>Booked and in the room.</h2>
            </div>
          </div>
          <div className="attendance-report">
            <div className="attendance-report-value">
              <strong>{attendanceRegistered.toLocaleString()}</strong>
              <span>places registered in completed sample months</span>
            </div>
            <div className="attendance-bar">
              <span style={{ width: `${attendanceRate}%` }} />
            </div>
            <div className="attendance-report-foot">
              <span>
                <i className="legend-dot legend-blue" />
                Registered
              </span>
              <strong>{attendedCount.toLocaleString()} attended</strong>
            </div>
            <div className="attendance-insight">
              <span>ROOM NOTE</span>
              <p>
                Attendance uses the sample attendance totals for completed
                months in the selected reporting window.
              </p>
            </div>
          </div>
        </section>
      </div>
      <div className="analytics-footer-note">
        <span>DEMO DATA</span> Revenue and attendance metrics are illustrative
        only. No real payment or attendance information is connected.
      </div>
    </>
  );
}
