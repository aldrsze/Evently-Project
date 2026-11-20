import { createContext, useContext, useEffect, useState, type AnchorHTMLAttributes, type MouseEvent } from 'react';

const NavigationContext = createContext<(to: string) => void>(() => undefined);

export function navigate(to: string, replace = false): void {
  if (replace) window.history.replaceState({}, '', to);
  else window.history.pushState({}, '', to);
  window.dispatchEvent(new PopStateEvent('popstate'));
  window.scrollTo({ top: 0, behavior: 'smooth' });
}

export function NavigationProvider({ children }: { children: React.ReactNode }) {
  return <NavigationContext.Provider value={navigate}>{children}</NavigationContext.Provider>;
}

export function useNavigate() {
  return useContext(NavigationContext);
}

export function usePath(): string {
  const [path, setPath] = useState(() => window.location.pathname + window.location.search);
  useEffect(() => {
    const update = () => setPath(window.location.pathname + window.location.search);
    window.addEventListener('popstate', update);
    return () => window.removeEventListener('popstate', update);
  }, []);
  return path;
}

interface LinkProps extends AnchorHTMLAttributes<HTMLAnchorElement> {
  to: string;
  children: React.ReactNode;
}

export function Link({ to, onClick, children, ...props }: LinkProps) {
  const move = useNavigate();
  const handleClick = (event: MouseEvent<HTMLAnchorElement>) => {
    onClick?.(event);
    if (event.defaultPrevented || event.metaKey || event.ctrlKey || event.shiftKey || event.altKey || event.button !== 0) return;
    if (to.startsWith('http') || to.startsWith('mailto:') || to.startsWith('#')) return;
    event.preventDefault();
    move(to);
  };
  return <a href={to} onClick={handleClick} {...props}>{children}</a>;
}
