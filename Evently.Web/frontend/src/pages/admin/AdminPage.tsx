import { lazy, Suspense } from "react";
import { usePath } from "../../lib/router";
import { WorkspaceLayout } from "../../components/WorkspaceLayout";

const AdminOverview = lazy(() => import("./AdminOverview"));
const EventEditorPage = lazy(() =>
  import("./EventsAdmin").then((module) => ({
    default: module.EventEditorPage,
  })),
);
const EventsAdminPage = lazy(() =>
  import("./EventsAdmin").then((module) => ({
    default: module.EventsAdminPage,
  })),
);
const PeopleAdminPage = lazy(() => import("./PeopleAdmin"));
const ReportsAdmin = lazy(() => import("./ReportsAdmin"));
const AdminSettingsPage = lazy(() =>
  import("./AdminSettings").then((module) => ({
    default: module.AdminSettingsPage,
  })),
);
const CategoriesAdmin = lazy(() =>
  import("./AdminSettings").then((module) => ({
    default: module.CategoriesAdmin,
  })),
);

function AdminContent() {
  const path = usePath().split("?")[0];
  if (path === "/admin/events/new" || path.endsWith("/edit"))
    return <EventEditorPage />;
  if (path === "/admin/events") return <EventsAdminPage />;
  if (path === "/admin/registrations" || path === "/admin/attendees")
    return <PeopleAdminPage />;
  if (path === "/admin/analytics") return <ReportsAdmin />;
  if (path === "/admin/categories") return <CategoriesAdmin />;
  if (path === "/admin/settings") return <AdminSettingsPage />;
  return <AdminOverview />;
}

export default function AdminPage() {
  return (
    <WorkspaceLayout kind="admin">
      <Suspense
        fallback={
          <div className="workspace-content" role="status" aria-live="polite">
            Loading organizer tools…
          </div>
        }
      >
        <AdminContent />
      </Suspense>
    </WorkspaceLayout>
  );
}
