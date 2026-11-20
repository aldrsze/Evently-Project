import {
  useEffect,
  useRef,
  type ButtonHTMLAttributes,
  type InputHTMLAttributes,
  type ReactNode,
} from "react";
import { AlertCircle, Check, X } from "lucide-react";

interface ButtonProps extends ButtonHTMLAttributes<HTMLButtonElement> {
  variant?: "primary" | "secondary" | "tertiary" | "dark";
  size?: "sm" | "md" | "lg";
  icon?: ReactNode;
}

export function Button({
  variant = "primary",
  size = "md",
  icon,
  className = "",
  children,
  ...props
}: ButtonProps) {
  return (
    <button
      className={`button button-${variant} button-${size} ${className}`}
      {...props}
    >
      {icon && <span className="button-icon">{icon}</span>}
      {children}
    </button>
  );
}

export function Badge({
  children,
  tone = "blue",
  dot = false,
  className = "",
}: {
  children: ReactNode;
  tone?: "blue" | "green" | "amber" | "red" | "purple" | "slate";
  dot?: boolean;
  className?: string;
}) {
  return (
    <span className={`badge badge-${tone} ${className}`}>
      {dot && <span className="badge-dot" />}
      {children}
    </span>
  );
}

interface FieldProps extends InputHTMLAttributes<HTMLInputElement> {
  label: string;
  error?: string;
  helper?: string;
  requiredMark?: boolean;
}

export function Field({
  label,
  error,
  helper,
  requiredMark = false,
  id,
  ...props
}: FieldProps) {
  const fieldId = id ?? props.name ?? label.toLowerCase().replace(/\W+/g, "-");
  const errorId = `${fieldId}-error`;
  return (
    <div className="field-group">
      <div className="field-label-row">
        <label htmlFor={fieldId}>
          {label}
          {requiredMark && (
            <span className="required-star" aria-hidden="true">
              {" "}
              *
            </span>
          )}
        </label>
        {error && (
          <span className="field-error" id={errorId} role="alert">
            <AlertCircle size={13} />
            {error}
          </span>
        )}
      </div>
      <input
        id={fieldId}
        className={`field-control ${error ? "field-invalid" : ""}`}
        aria-invalid={Boolean(error)}
        aria-describedby={
          error ? errorId : helper ? `${fieldId}-helper` : undefined
        }
        {...props}
      />
      {helper && !error && (
        <p className="field-helper" id={`${fieldId}-helper`}>
          {helper}
        </p>
      )}
    </div>
  );
}

export function SelectField({
  label,
  value,
  onChange,
  options,
  id,
  error,
  requiredMark = false,
}: {
  label: string;
  value: string;
  onChange: (event: React.ChangeEvent<HTMLSelectElement>) => void;
  options: { label: string; value: string }[];
  id?: string;
  error?: string;
  requiredMark?: boolean;
}) {
  const fieldId = id ?? label.toLowerCase().replace(/\W+/g, "-");
  const errorId = `${fieldId}-error`;
  return (
    <div className="field-group">
      <div className="field-label-row">
        <label htmlFor={fieldId}>
          {label}
          {requiredMark && <span className="required-star"> *</span>}
        </label>
        {error && (
          <span className="field-error" id={errorId} role="alert">
            <AlertCircle size={13} />
            {error}
          </span>
        )}
      </div>
      <select
        id={fieldId}
        className={`field-control select-control ${error ? "field-invalid" : ""}`}
        value={value}
        onChange={onChange}
        aria-invalid={Boolean(error)}
        aria-describedby={error ? errorId : undefined}
      >
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
    </div>
  );
}

export function TextAreaField({
  label,
  value,
  onChange,
  rows = 5,
  error,
  helper,
  requiredMark = false,
  id,
  placeholder,
}: {
  label: string;
  value: string;
  onChange: (event: React.ChangeEvent<HTMLTextAreaElement>) => void;
  rows?: number;
  error?: string;
  helper?: string;
  requiredMark?: boolean;
  id?: string;
  placeholder?: string;
}) {
  const fieldId = id ?? label.toLowerCase().replace(/\W+/g, "-");
  const errorId = `${fieldId}-error`;
  return (
    <div className="field-group">
      <div className="field-label-row">
        <label htmlFor={fieldId}>
          {label}
          {requiredMark && <span className="required-star"> *</span>}
        </label>
        {error && (
          <span className="field-error" id={errorId} role="alert">
            <AlertCircle size={13} />
            {error}
          </span>
        )}
      </div>
      <textarea
        id={fieldId}
        className={`field-control textarea-control ${error ? "field-invalid" : ""}`}
        rows={rows}
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        aria-invalid={Boolean(error)}
        aria-describedby={
          error ? errorId : helper ? `${fieldId}-helper` : undefined
        }
      />
      {helper && !error && (
        <p className="field-helper" id={`${fieldId}-helper`}>
          {helper}
        </p>
      )}
    </div>
  );
}

export function Modal({
  title,
  onClose,
  children,
  footer,
}: {
  title: string;
  onClose: () => void;
  children: ReactNode;
  footer?: ReactNode;
}) {
  const dialogRef = useRef<HTMLElement | null>(null);
  const onCloseRef = useRef(onClose);
  useEffect(() => {
    onCloseRef.current = onClose;
  }, [onClose]);
  useEffect(() => {
    const previouslyFocused =
      document.activeElement instanceof HTMLElement
        ? document.activeElement
        : null;
    const dialog = dialogRef.current;
    const focusableSelector =
      'a[href], button:not([disabled]), input:not([disabled]), select:not([disabled]), textarea:not([disabled]), [tabindex]:not([tabindex="-1"])';
    const focusable = () =>
      Array.from(
        dialog?.querySelectorAll<HTMLElement>(focusableSelector) ?? [],
      );
    (focusable()[0] ?? dialog)?.focus();
    const handleKey = (event: KeyboardEvent) => {
      if (event.key === "Escape") {
        event.preventDefault();
        onCloseRef.current();
        return;
      }
      if (event.key !== "Tab") return;
      const items = focusable();
      if (!items.length) {
        event.preventDefault();
        dialog?.focus();
        return;
      }
      const first = items[0];
      const last = items[items.length - 1];
      if (
        event.shiftKey &&
        (document.activeElement === first || document.activeElement === dialog)
      ) {
        event.preventDefault();
        last.focus();
      } else if (!event.shiftKey && document.activeElement === last) {
        event.preventDefault();
        first.focus();
      }
    };
    window.addEventListener("keydown", handleKey);
    return () => {
      window.removeEventListener("keydown", handleKey);
      previouslyFocused?.focus();
    };
  }, []);
  return (
    <div
      className="modal-backdrop"
      role="presentation"
      onMouseDown={(event) => {
        if (event.target === event.currentTarget) onClose();
      }}
    >
      <section
        ref={dialogRef}
        className="modal"
        role="dialog"
        aria-modal="true"
        aria-labelledby="modal-title"
        tabIndex={-1}
      >
        <header className="modal-header">
          <h2 id="modal-title">{title}</h2>
          <button
            className="icon-button"
            onClick={onClose}
            aria-label="Close dialog"
          >
            <X size={18} />
          </button>
        </header>
        <div className="modal-body">{children}</div>
        {footer && <footer className="modal-footer">{footer}</footer>}
      </section>
    </div>
  );
}

export function EmptyState({
  title,
  description,
  icon,
  action,
}: {
  title: string;
  description: string;
  icon?: ReactNode;
  action?: ReactNode;
}) {
  return (
    <div className="empty-state">
      <div className="empty-icon">{icon ?? <Check size={22} />}</div>
      <h3>{title}</h3>
      <p>{description}</p>
      {action}
    </div>
  );
}

export function PageTitle({
  eyebrow,
  title,
  description,
  action,
}: {
  eyebrow?: string;
  title: string;
  description?: string;
  action?: ReactNode;
}) {
  return (
    <div className="page-title-row">
      <div>
        {eyebrow && <div className="eyebrow">{eyebrow}</div>}
        <h1>{title}</h1>
        {description && <p>{description}</p>}
      </div>
      {action && <div className="page-title-action">{action}</div>}
    </div>
  );
}
