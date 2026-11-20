import { useState } from "react";
import { ArrowUpRight, Menu, X } from "lucide-react";
import { Link } from "../lib/router";
import { categories } from "../data/events";

export function Brand({ light = false }: { light?: boolean }) {
  return (
    <Link
      className={`brand ${light ? "brand-light" : ""}`}
      to="/"
      aria-label="Evently home"
    >
      <span className="brand-mark" aria-hidden="true">
        <i />
        <i />
        <i />
        <i />
      </span>
      <span>evently</span>
    </Link>
  );
}

export function PublicLayout({ children }: { children: React.ReactNode }) {
  const [menuOpen, setMenuOpen] = useState(false);
  const close = () => setMenuOpen(false);
  return (
    <div className="public-shell">
      <a className="skip-link" href="#main-content">
        Skip to content
      </a>
      <header className="site-header">
        <div className="site-header-inner">
          <Brand />
          <nav
            className={`site-nav ${menuOpen ? "nav-open" : ""}`}
            aria-label="Main navigation"
          >
            <Link to="/" onClick={close}>
              Home
            </Link>
            <Link to="/events" onClick={close}>
              Explore events
            </Link>
            <a href="/#categories" onClick={close}>
              Categories
            </a>
            <Link to="/about" onClick={close}>
              About
            </Link>
            <Link to="/contact" onClick={close}>
              Contact
            </Link>
            <div className="mobile-nav-actions">
              <Link className="mobile-login" to="/login" onClick={close}>
                Sign in
              </Link>
              <Link
                className="button button-primary button-sm"
                to="/signup"
                onClick={close}
              >
                Get started
              </Link>
            </div>
          </nav>
          <div className="header-actions">
            <Link className="header-login" to="/login">
              Sign in
            </Link>
            <Link
              className="button button-primary button-sm header-cta"
              to="/signup"
            >
              Get started <ArrowUpRight size={15} />
            </Link>
            <button
              className="mobile-menu-toggle"
              aria-label={menuOpen ? "Close menu" : "Open menu"}
              aria-expanded={menuOpen}
              onClick={() => setMenuOpen((value) => !value)}
            >
              {menuOpen ? <X size={21} /> : <Menu size={21} />}
            </button>
          </div>
        </div>
      </header>
      <main id="main-content">{children}</main>
      <Footer />
    </div>
  );
}

function Footer() {
  return (
    <footer className="site-footer">
      <div className="footer-main">
        <div className="footer-brand-block">
          <Brand light />
          <p>
            Make room for something memorable. Find the gathering you’ll be glad
            you didn’t miss.
          </p>
          <div className="footer-social">
            <a href="https://instagram.com" target="_blank" rel="noreferrer">
              Instagram
            </a>
            <a href="https://linkedin.com" target="_blank" rel="noreferrer">
              LinkedIn
            </a>
            <a href="https://x.com" target="_blank" rel="noreferrer">
              X / Twitter
            </a>
          </div>
        </div>
        <div className="footer-column">
          <h3>Explore</h3>
          <Link to="/events">All events</Link>
          <a href="/#categories">Categories</a>
          <Link to="/about">Our story</Link>
          <Link to="/contact">Contact</Link>
        </div>
        <div className="footer-column">
          <h3>For organizers</h3>
          <Link to="/admin">Organizer workspace</Link>
          <Link to="/admin/events/new">Create an event</Link>
          <Link to="/signup">Join Evently</Link>
        </div>
        <div className="footer-column footer-categories">
          <h3>Discover by category</h3>
          {categories.slice(0, 4).map((category) => (
            <Link
              key={category.name}
              to={`/events?category=${encodeURIComponent(category.name)}`}
            >
              {category.name}
            </Link>
          ))}
        </div>
      </div>
      <div className="footer-bottom">
        <span>© 2026 Evently, Inc. Thoughtfully gathered.</span>
        <div>
          <a
            href="#privacy"
            onClick={(event) => {
              event.preventDefault();
              window.alert(
                "Privacy information is part of this frontend demonstration.",
              );
            }}
          >
            Privacy
          </a>
          <a
            href="#terms"
            onClick={(event) => {
              event.preventDefault();
              window.alert(
                "Terms information is part of this frontend demonstration.",
              );
            }}
          >
            Terms
          </a>
          <span className="footer-note">
            A frontend demo. No real bookings or payments.
          </span>
        </div>
      </div>
    </footer>
  );
}
