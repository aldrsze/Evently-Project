import { useState, type ReactNode } from "react";
import {
  Activity,
  BarChart3,
  CalendarDays,
  ChevronDown,
  CircleHelp,
  FilePlus2,
  LayoutDashboard,
  LogOut,
  Menu,
  Settings,
  Ticket,
  Users,
  X,
} from "lucide-react";
import { useApp } from "../lib/app-context";
import { Link, useNavigate } from "../lib/router";
import { Brand } from "./PublicLayout";

const attendeeItems = [
  { label: "Overview", path: "/dashboard", icon: LayoutDashboard },
  { label: "My registrations", path: "/dashboard/registrations", icon: Ticket },
  { label: "Saved events", path: "/dashboard/saved", icon: CalendarDays },
  { label: "Profile settings", path: "/dashboard/profile", icon: Settings },
];

const adminItems = [
  { label: "Overview", path: "/admin", icon: LayoutDashboard },
  { label: "Events", path: "/admin/events", icon: CalendarDays },
  { label: "Create event", path: "/admin/events/new", icon: FilePlus2 },
  { label: "Registrations", path: "/admin/registrations", icon: Ticket },
  { label: "Attendees", path: "/admin/attendees", icon: Users },
  { label: "Categories", path: "/admin/categories", icon: CalendarDays },
  { label: "Reports & analytics", path: "/admin/analytics", icon: BarChart3 },
  { label: "Settings", path: "/admin/settings", icon: Settings },
];

export function WorkspaceLayout({
  children,
  kind = "attendee",
}: {
  children: ReactNode;
  kind?: "attendee" | "admin";
}) {
  const { user, setUser, notify } = useApp();
  const [open, setOpen] = useState(false);
  const path = window.location.pathname;
  const navigate = useNavigate();
  const admin = kind === "admin";
  const items = admin ? adminItems : attendeeItems;
  const name = user?.name ?? "Alex Morgan";
  const signOut = () => {
    setUser(null);
    notify("You have signed out of this demo.");
    navigate("/");
  };
  return (
    <div
      className={`workspace-shell ${admin ? "admin-workspace" : "attendee-workspace"}`}
    >
      <button
        className="workspace-mobile-toggle"
        aria-label={open ? "Close sidebar" : "Open sidebar"}
        aria-expanded={open}
        onClick={() => setOpen((value) => !value)}
      >
        {open ? <X size={20} /> : <Menu size={20} />}
        <span>{admin ? "Workspace menu" : "My account"}</span>
      </button>
      {open && (
        <button
          className="workspace-overlay"
          onClick={() => setOpen(false)}
          aria-label="Close sidebar"
        />
      )}
      <aside className={`workspace-sidebar ${open ? "sidebar-open" : ""}`}>
        <div className="workspace-brand">
          <Brand />
          <span className="workspace-plan">
            {admin ? "ORGANIZER" : "ATTENDEE"}
          </span>
        </div>
        <div className="workspace-profile">
          <div className="avatar avatar-blue">
            {name
              .split(" ")
              .map((part) => part[0])
              .slice(0, 2)
              .join("")}
          </div>
          <div>
            <strong>{name}</strong>
            <span>{admin ? "Organizer account" : "Member account"}</span>
          </div>
          <ChevronDown size={15} />
        </div>
        <div className="workspace-nav-label">
          {admin ? "MANAGE" : "YOUR SPACE"}
        </div>
        <nav
          className="workspace-nav"
          aria-label={admin ? "Admin navigation" : "Attendee navigation"}
        >
          {items.map(({ label, path: itemPath, icon: Icon }) => (
            <Link
              key={itemPath}
              to={itemPath}
              className={`workspace-nav-item ${path === itemPath || (itemPath !== "/admin" && itemPath !== "/dashboard" && path.startsWith(itemPath)) ? "active" : ""}`}
              onClick={() => setOpen(false)}
            >
              <Icon size={17} strokeWidth={1.8} />
              <span>{label}</span>
              {label === "Registrations" && admin && (
                <span className="nav-count">8</span>
              )}
            </Link>
          ))}
        </nav>
        <div className="workspace-sidebar-bottom">
          <Link
            to={admin ? "/" : "/events"}
            className="workspace-nav-item"
            onClick={() => setOpen(false)}
          >
            <Activity size={17} />
            <span>{admin ? "View public site" : "Find an event"}</span>
          </Link>
          <Link
            to="/contact"
            className="workspace-nav-item"
            onClick={() => setOpen(false)}
          >
            <CircleHelp size={17} />
            <span>Help & support</span>
          </Link>
          <button className="workspace-nav-item logout-link" onClick={signOut}>
            <LogOut size={17} />
            <span>Sign out</span>
          </button>
        </div>
      </aside>
      <div className="workspace-main">
        <header className="workspace-topbar">
          <div className="workspace-breadcrumb">
            <span>{admin ? "Organizer workspace" : "My Evently"}</span>
            <span>/</span>
            <strong>
              {admin
                ? (items.find((item) => item.path === path)?.label ??
                  "Overview")
                : (items.find((item) => item.path === path)?.label ??
                  "Overview")}
            </strong>
          </div>
          <div className="workspace-topbar-actions">
            <button
              className="topbar-icon"
              aria-label="Help"
              onClick={() => navigate("/contact")}
            >
              <CircleHelp size={18} />
            </button>
            <span className="topbar-divider" />
            <div
              className="avatar avatar-peach"
              aria-label={`Signed in as ${name}`}
            >
              {name
                .split(" ")
                .map((part) => part[0])
                .slice(0, 2)
                .join("")}
            </div>
          </div>
        </header>
        <div className="workspace-content">{children}</div>
      </div>
    </div>
  );
}
