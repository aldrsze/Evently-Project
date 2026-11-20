import { lazy, Suspense, useEffect } from "react";
import { AppProvider } from "./lib/app-context";
import { NavigationProvider, Link, usePath } from "./lib/router";
import { PublicLayout } from "./components/PublicLayout";
import { EmptyState } from "./components/ui";

const HomePage = lazy(() => import("./pages/public/HomePage"));
const ExplorePage = lazy(() => import("./pages/public/ExplorePage"));
const EventDetailPage = lazy(() => import("./pages/public/EventDetailPage"));
const RegistrationPage = lazy(() => import("./pages/public/RegistrationPage"));
const AboutPage = lazy(() =>
  import("./pages/public/InformationPages").then((module) => ({
    default: module.AboutPage,
  })),
);
const AuthPage = lazy(() =>
  import("./pages/public/InformationPages").then((module) => ({
    default: module.AuthPage,
  })),
);
const ContactPage = lazy(() =>
  import("./pages/public/InformationPages").then((module) => ({
    default: module.ContactPage,
  })),
);
const AttendeePage = lazy(() => import("./pages/attendee/AttendeePages"));
const AdminPage = lazy(() => import("./pages/admin/AdminPage"));

function RouteLoading() {
  return (
    <div
      className="page-container route-loading"
      role="status"
      aria-live="polite"
    >
      Loading Evently…
    </div>
  );
}

function NotFound() {
  return (
    <div className="page-container not-found">
      <EmptyState
        title="This page is a little off the map."
        description="Let’s find something good that’s happening."
        action={
          <Link className="button button-primary button-md" to="/events">
            Explore events
          </Link>
        }
      />
    </div>
  );
}

function RouteContent() {
  const path = usePath().split("?")[0];
  useEffect(() => {
    const titles: Record<string, string> = {
      "/": "Discover experiences — Evently",
      "/events": "Explore events — Evently",
      "/about": "About — Evently",
      "/contact": "Contact — Evently",
      "/login": "Sign in — Evently",
      "/signup": "Create account — Evently",
      "/forgot-password": "Reset password — Evently",
      "/dashboard": "My Evently — Your attendee space",
      "/admin": "Organizer workspace — Evently",
      "/admin/events": "Manage events — Evently",
      "/admin/events/new": "Create an event — Evently",
      "/admin/registrations": "Registrations — Evently",
      "/admin/attendees": "Attendees — Evently",
      "/admin/categories": "Categories — Evently",
      "/admin/analytics": "Reports & analytics — Evently",
      "/admin/settings": "Workspace settings — Evently",
    };
    const title =
      titles[path] ??
      (path.startsWith("/events/")
        ? "Event details — Evently"
        : path.startsWith("/dashboard/")
          ? "My Evently — Your attendee space"
          : path.startsWith("/admin/events/")
            ? "Edit event — Evently"
            : "Evently — Make room for something memorable");
    document.title = title;
  }, [path]);

  if (path === "/register" || path.startsWith("/register/"))
    return <RegistrationPage />;
  if (path.startsWith("/dashboard")) return <AttendeePage />;
  if (path.startsWith("/admin")) return <AdminPage />;

  let page = null;
  if (path === "/") page = <HomePage />;
  else if (path === "/events") page = <ExplorePage />;
  else if (/^\/events\/[^/]+$/.test(path)) page = <EventDetailPage />;
  else if (path === "/about") page = <AboutPage />;
  else if (path === "/contact") page = <ContactPage />;
  else if (path === "/login") page = <AuthPage kind="login" />;
  else if (path === "/signup") page = <AuthPage kind="signup" />;
  else if (path === "/forgot-password") page = <AuthPage kind="forgot" />;
  else page = <NotFound />;
  return (
    <PublicLayout>
      <Suspense fallback={<RouteLoading />}>{page}</Suspense>
    </PublicLayout>
  );
}

export default function App() {
  return (
    <NavigationProvider>
      <AppProvider>
        <Suspense fallback={<RouteLoading />}>
          <RouteContent />
        </Suspense>
      </AppProvider>
    </NavigationProvider>
  );
}
