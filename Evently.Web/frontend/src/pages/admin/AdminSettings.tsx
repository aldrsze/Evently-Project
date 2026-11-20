import {
  Check,
  ChevronRight,
  CircleHelp,
  Globe2,
  LockKeyhole,
  Settings2,
  SlidersHorizontal,
} from "lucide-react";
import { useApp } from "../../lib/app-context";
import { Link } from "../../lib/router";
import { categories } from "../../data/events";
import type { AdminSettings } from "../../types";
import { Button, PageTitle } from "../../components/ui";

export function CategoriesAdmin() {
  const { notify, categoryVisibility, setCategoryVisibility } = useApp();
  const toggle = (name: string) => {
    const next = { ...categoryVisibility, [name]: !categoryVisibility[name] };
    setCategoryVisibility(next);
    notify(
      `${name} ${next[name] ? "shown" : "hidden"} in the public category list.`,
    );
  };
  const restore = () => {
    setCategoryVisibility(
      Object.fromEntries(categories.map((item) => [item.name, true])),
    );
    notify("All categories are visible again.");
  };

  return (
    <>
      <PageTitle
        eyebrow="HELP PEOPLE FIND THEIR THING"
        title="Categories."
        description="Choose which categories appear on the public home page and explore filters."
        action={
          <Button variant="secondary" onClick={restore}>
            Restore defaults
          </Button>
        }
      />
      <div className="category-admin-grid">
        {categories.map((item, index) => (
          <article
            className={`category-admin-card ${categoryVisibility[item.name] ? "" : "category-muted"}`}
            key={item.name}
          >
            <div className={`category-admin-art category-${item.color}`}>
              <img src={item.image} alt="" loading="lazy" />
              <span>0{index + 1}</span>
            </div>
            <div>
              <span className="eyebrow">
                CATEGORY {String(index + 1).padStart(2, "0")}
              </span>
              <h2>{item.name}</h2>
              <p>{item.short}</p>
            </div>
            <div className="category-admin-bottom">
              <span>
                {categoryVisibility[item.name]
                  ? "Visible to visitors"
                  : "Hidden from visitors"}
              </span>
              <button
                className={`toggle-button ${categoryVisibility[item.name] ? "toggle-on" : ""}`}
                role="switch"
                aria-checked={Boolean(categoryVisibility[item.name])}
                aria-label={`${categoryVisibility[item.name] ? "Hide" : "Show"} ${item.name}`}
                onClick={() => toggle(item.name)}
              >
                <span />
              </button>
            </div>
          </article>
        ))}
      </div>
      <div className="admin-simulation-note">
        Visibility changes apply immediately to the public category list and
        remain saved in this browser.
      </div>
    </>
  );
}

export function AdminSettingsPage() {
  const { notify, adminSettings, setAdminSettings } = useApp();
  const change = (key: keyof AdminSettings) => {
    const next = { ...adminSettings, [key]: !adminSettings[key] };
    setAdminSettings(next);
    notify("Organizer preference saved in this browser.");
  };
  const rows: {
    key: keyof AdminSettings;
    label: string;
    description: string;
  }[] = [
    {
      key: "registrations",
      label: "Recent registration activity",
      description:
        "Show or hide the latest registrations panel on the organizer overview.",
    },
    {
      key: "newEvent",
      label: "Draft event reminders",
      description: "Show a reminder card while any event is still a draft.",
    },
    {
      key: "weeklyDigest",
      label: "Weekly organizer summary",
      description:
        "Show a local summary of registrations and upcoming events on the overview.",
    },
    {
      key: "publicProfile",
      label: "Public organizer contact panel",
      description: "Show or hide organizer contact details on event pages.",
    },
  ];

  return (
    <>
      <PageTitle
        eyebrow="MAKE IT FEEL LIKE YOURS"
        title="Workspace settings."
        description="A few controls for how your organizer space behaves."
      />
      <div className="admin-settings-layout">
        <section className="dashboard-panel settings-section">
          <div className="panel-heading">
            <div>
              <span className="eyebrow">WORKSPACE PREFERENCES</span>
              <h2>Keep it useful.</h2>
            </div>
            <Settings2 size={18} />
          </div>
          {rows.map((row) => (
            <label className="preference-row" key={row.key}>
              <span>
                <strong>{row.label}</strong>
                <small>{row.description}</small>
              </span>
              <input
                type="checkbox"
                checked={adminSettings[row.key]}
                onChange={() => change(row.key)}
              />
              <span className="toggle-track" />
            </label>
          ))}
        </section>
        <div className="settings-side">
          <section className="dashboard-panel settings-section">
            <span className="eyebrow">PLATFORM</span>
            <h2>Evently demo</h2>
            <p>
              Frontend-only event management workspace. Changes are kept in your
              browser.
            </p>
            <div className="settings-detail-line">
              <Globe2 size={16} />
              <span>Language</span>
              <strong>English (US)</strong>
            </div>
            <div className="settings-detail-line">
              <LockKeyhole size={16} />
              <span>Authentication</span>
              <strong>Simulated</strong>
            </div>
            <div className="settings-detail-line">
              <SlidersHorizontal size={16} />
              <span>Build</span>
              <strong>Frontend preview</strong>
            </div>
          </section>
          <section className="settings-help">
            <CircleHelp size={18} />
            <div>
              <strong>Need a hand?</strong>
              <p>Send a note to the Evently team in the demo.</p>
              <Link to="/contact">
                Contact support <ChevronRight size={13} />
              </Link>
            </div>
          </section>
        </div>
      </div>
      <section className="dashboard-panel admin-about-panel">
        <span className="eyebrow">CLEAR ABOUT THE DEMO</span>
        <h2>No real users or messages are connected.</h2>
        <p>
          All preferences and notifications are local-only. This workspace
          demonstrates organizer flows; it does not replace a production event
          management system.
        </p>
        <span className="demo-saved-indicator">
          <Check size={14} />
          Your preferences are saved in this browser
        </span>
      </section>
    </>
  );
}
