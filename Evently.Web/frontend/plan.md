# Evently implementation plan

## Approved scope
Build the supplied Evently product as an ASP.NET Core MVC application using Razor views, CSS, and modular vanilla JavaScript. The app is a frontend-only demonstration: no database, API, payment gateway, real authentication, or storage of real passwords/payment details. User-visible event, booking, organizer, profile, and analytics data must be clearly marked as sample/demo data.

The managed workspace was initialized empty and has no .NET SDK installed. Install the SDK into this project environment for development, build and run the Razor application there, and stop to ask before changing frameworks if that cannot be made reliable. Keep the managed project configured with server and database features disabled. Do not publish unless separately requested.

## Product architecture
- ASP.NET Core MVC routes and controllers serve distinct Razor pages for Home; Events/Index and Events/Details/{id}; Booking/Checkout and Booking/Success; Dashboard overview, bookings, and favorites; Organizer overview and CreateEvent; Admin overview; and Account Login, Register, and ForgotPassword.
- Keep event fixtures centralized in a Philippine-only demo catalog. Use reusable Razor partials for the site shell, navigation, footer, cards, badges, statistics, and dialogs. Use JavaScript modules for local demo state, event discovery/filtering, booking, dashboard/organizer/admin interactions, and accessible UI behaviors.
- Persist only non-sensitive demonstration data (favorites, simulated bookings, created demo events, and profile edits) to localStorage. Never persist typed passwords or payment credentials. Include a reset-demo-data control.
- Provide a demo ticket download from browser-generated content. Payment options are presentational only.

## Project structure
```text
Controllers/       MVC page controllers for public, booking, attendee, organizer, admin, and account routes
Models/            View models and demo event/ticket types (no persistence layer)
Services/          Centralized sample catalog and route/view presentation helpers only
Views/             Razor page views grouped by controller
Views/Shared/      Shared layout, navigation/footer and reusable partials
wwwroot/css/       Design tokens, responsive layout, component and page styling
wwwroot/js/        Central demo data/state plus focused interaction modules
wwwroot/images/    Curated/generated assets used by the interface
Program.cs         MVC/static-file route setup; no backend product services
```

## Design system
- **Movement:** contemporary event editorial with product-grade dashboard polish, inspired by the supplied Eventbrite/Luma/Linear references without cloning them.
- **Core principles:** high-energy discovery; clear trust and demo-data cues; tactile cards and booking controls; one coherent system across public and dashboard routes.
- **Color philosophy:** midnight navy (#101828) grounds trust; electric violet (#7657F6) is the ownable brand signature; orange (#FF914D), yellow (#FFD166), and mint (#42D6A4) add event energy and status cues; off-white/soft gray backgrounds protect readability.
- **Layout paradigm:** a roomy editorial landing page with asymmetrical hero composition and floating event details, followed by compact adaptive event grids and clear filter/dashboard rails.
- **Signature elements:** a custom ticket-notch/wayfinder Evently mark; violet category chips with warm accent dots; small “DEMO DATA” labels placed beside event schedules, metrics, and prices.
- **Interaction and animation:** direct, reversible actions with inline feedback; 150–300ms easing for hover, drawer, modal, and toast states; reduced-motion support and no unnecessary bounce.
- **Typography:** Plus Jakarta Sans headings and Inter body copy; bold editorial hero, medium/semibold labels, consistent 8px spacing, 16–24px card radii, restrained shadows and visible focus states.
- **Brand essence:** the Philippine-local guide to experiences worth going out for; energetic, welcoming, dependable. Voice is specific and inviting, e.g. “Find your next local favorite.” and “Good plans start nearby.” Logo is a compact violet ticket/wayfinder glyph paired with a custom-weight Evently wordmark.

## Data and accuracy
Create at least 18 demo records, including the 15 supplied event concepts and additional photography, technology, business, art, food, and fitness activities. Use Philippine venues/cities and cover Quezon City, Manila, Makati, Pasig, Taguig, Cebu City, Davao City, Baguio City, Iloilo City, Bacolod City, Cagayan de Oro, Batangas, Pampanga, Palawan, and Siargao. All records, schedules, organizers, locations, availability, prices, metrics, testimonials, and bookings are visibly labeled as demonstration content; recurring festivals are not represented as verified upcoming editions. Display Philippine Peso and Philippine date formatting.

## Build workflow
After this plan was approved, create/update TODO.md with source requirements grouped by deliverable outcome. Configure available HTML/CSS/JavaScript diagnostics before the first code batch, curate/generate image assets, then build the MVC shell, page routes, shared design system, centralized demo data, and interactions. Build and smoke-check principal routes and the end-to-end simulated booking path; resolve issues found. Preserve frontend-only boundaries throughout.
