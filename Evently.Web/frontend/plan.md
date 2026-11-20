# Evently — implementation and design plan

## Approved product scope

Build a frontend-only, responsive event discovery and management platform. Attendees can discover, save and register for events; administrators can create and manage events, registrations, attendees and reports. Use centralized mock records and localStorage for user-facing persistence. No server, database, real authentication, or payment integration.

## Implementation approach

- Start from the empty initialized workspace with React, TypeScript and Vite; keep the runtime frontend-only on port 3000.
- Use a lightweight History API router with explicit static and dynamic routes. Keep domain data in centralized typed fixtures and localStorage helpers; share reusable form, card, button, modal, toast, navigation and layout components.
- Use Lucide React for interface icons, Recharts for mock analytics, and authored CSS/design tokens for a distinctive responsive visual system. Avoid unnecessary dependencies and generated backend code.
- Organize app routes into public discovery/content, account simulation, attendee workspace and admin workspace. Keep multi-step registration and event creation forms controlled with inline validation. Make all state-changing actions visible and persist supported state locally.
- Core routes: `/`, `/events`, `/events/:id`, `/register/:id`, `/about`, `/contact`, `/login`, `/signup`, `/forgot-password`, `/dashboard`, `/dashboard/registrations`, `/dashboard/saved`, `/dashboard/profile`, `/admin`, `/admin/events`, `/admin/events/new`, `/admin/events/:id/edit`, `/admin/registrations`, `/admin/attendees`, `/admin/analytics`, `/admin/settings`.

## Project structure

- `src/main.tsx`, `src/App.tsx`: bootstrap, route resolution and shared state boundaries.
- `src/data/`: typed event, category, attendee, registration and analytics demo fixtures.
- `src/lib/`: browser persistence, formatters, validation and small UI utilities.
- `src/components/`: reusable public navigation/footer, event cards/filters, forms, dialogs, toast, badges and dashboard shell.
- `src/pages/public/`: Home, Explore, Event details, Registration, About, Contact and authentication pages.
- `src/pages/attendee/`: dashboard overview, registrations, saved events and profile.
- `src/pages/admin/`: overview, event list/editor, registrations, attendees, analytics and settings.
- `src/styles/`: design tokens, typography, responsive layout and page/component styles.
- `public/`: route manifest and generated site imagery.

## Design direction

Three styles considered: **editorial event journal** (0.08, selected), **Swiss SaaS utility** (0.06), and **nocturne culture-club aesthetic** (0.04).

- **Design Movement:** Editorial event-journal design blended with contemporary SaaS product clarity.
- **Core Principles:** Discovery before administration; visual storytelling anchored by strong event photography; precise hierarchy and generous breathing room; consistent components that remain usable and accessible.
- **Color Philosophy:** Cobalt communicates confident action and navigation; deep ink navy provides trust and contrast; warm off-white and pale blue-gray create a calm paper-like canvas; coral, lilac and green distinguish event categories and statuses sparingly.
- **Layout Paradigm:** An asymmetrical editorial landing-page hero and image-led event feed lead into more structured dashboard workspaces. Wide content rails, quiet dividers and a persistent utility header keep pages readable without defaulting to generic centered grids.
- **Signature Elements:** A compact Evently wordmark with a custom linked-dot/asterisk mark; thin cobalt rules and date chips that evoke a printed event listing; high-quality photographic crops inside consistent nested card geometry.
- **Interaction Philosophy:** Clear action hierarchy and immediate visible feedback; progressive disclosure for multi-step flows; keyboard-friendly controls, inline validation and restrained confirmation dialogs.
- **Animation:** One low-distance fade/slide entrance for the hero and restrained short transitions for menus, cards and dialogs. Honor `prefers-reduced-motion`; no looping decorative movement.
- **Typography System:** Inter for product UI and body text with a refined high-contrast editorial serif for display headlines; use an accessible type scale, tight display leading and comfortable body line-height.
- **Brand Essence:** A considered way for curious people and organizers to find and host experiences worth showing up for. Personality: inviting, assured, thoughtful.
- **Brand Voice:** Specific, human and action-oriented, with practical event details before hype. Example lines: “Make room for something memorable.” and “Find your people. Save your seat.”
- **Wordmark & Logo:** A custom four-point meeting mark built from linked cobalt circles beside the lowercase Evently wordmark; use the icon alone only where the wordmark cannot fit.
- **Signature Brand Color:** Evently cobalt `#2563EB`, supported by deep navy `#0F172A` and soft paper-white `#F8FAFC`.

## Functional and quality scope

- Implement the requested public discovery, information, registration and mock-account experiences; attendee and admin views; responsive navigation; event filtering, sorting, saving and CRUD; registration status management and CSV export; profile preferences; dialogs/toasts; and localStorage persistence.
- Include at least 12 believable sample events, 5+ categories, 6 attendees, 8 registrations, 4 organizers and mock analytics across free/paid and varied statuses.
- Use semantic markup, labels, keyboard focus, readable contrast, reduced-motion support and responsive layouts. Clearly label authentication/payment and mock submission behavior as frontend simulations.
- Static route manifest must match application routes. Production output must build successfully; no external service is required to use core interactions.
