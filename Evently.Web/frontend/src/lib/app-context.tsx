import { createContext, useCallback, useContext, useEffect, useState, type ReactNode } from 'react';
import { categories, initialAttendees, initialEvents, initialRegistrations } from '../data/events';
import type { AdminSettings, AppContextValue, Profile, UserSession } from '../types';
import { readStored, writeStored } from './storage';

const profileDefault: Profile = {
  name: 'Alex Morgan', email: 'alex.morgan@example.com', phone: '(415) 555-0175', organization: 'Field Notes Studio', title: 'Curious attendee',
  notifications: { eventUpdates: true, reminders: true, newsletter: false },
};

const AppContext = createContext<AppContextValue | null>(null);

export function AppProvider({ children }: { children: ReactNode }) {
  const [events, setEvents] = useState(() => readStored('evently.events', initialEvents).map((item) => item.category === 'Music & Entertainment' ? { ...item, category: 'Music and Entertainment' } : item));
  const [registrations, setRegistrations] = useState(() => readStored('evently.registrations', initialRegistrations));
  const [attendees, setAttendees] = useState(() => readStored('evently.attendees', initialAttendees));
  const [savedEvents, setSavedEvents] = useState(() => readStored<string[]>('evently.saved', ['giant-lantern-festival-2026', 'sinulog-festival-2027']));
  const [profile, setProfile] = useState(() => readStored('evently.profile', profileDefault));
  const [user, setUser] = useState(() => readStored<UserSession | null>('evently.session', null));
  const [categoryVisibility, setCategoryVisibility] = useState<Record<string, boolean>>(() => {
    const defaults = Object.fromEntries(categories.map((item) => [item.name, true]));
    const stored = readStored<Record<string, boolean>>('evently.categoryVisibility', defaults);
    const visibility = { ...defaults, ...stored };
    if (!('Music and Entertainment' in stored) && 'Music & Entertainment' in stored) visibility['Music and Entertainment'] = stored['Music & Entertainment'];
    delete visibility['Music & Entertainment'];
    return visibility;
  });
  const [adminSettings, setAdminSettings] = useState<AdminSettings>(() => readStored('evently.adminSettings', {
    registrations: true, newEvent: true, weeklyDigest: false, publicProfile: true,
  }));
  const [toasts, setToasts] = useState<{ id: number; message: string; kind: 'success' | 'error' | 'info' }[]>([]);

  useEffect(() => writeStored('evently.events', events), [events]);
  useEffect(() => writeStored('evently.registrations', registrations), [registrations]);
  useEffect(() => writeStored('evently.attendees', attendees), [attendees]);
  useEffect(() => writeStored('evently.saved', savedEvents), [savedEvents]);
  useEffect(() => writeStored('evently.profile', profile), [profile]);
  useEffect(() => writeStored('evently.session', user), [user]);
  useEffect(() => writeStored('evently.categoryVisibility', categoryVisibility), [categoryVisibility]);
  useEffect(() => writeStored('evently.adminSettings', adminSettings), [adminSettings]);

  const notify = useCallback((message: string, kind: 'success' | 'error' | 'info' = 'success') => {
    const id = Date.now() + Math.random();
    setToasts((items) => [...items, { id, message, kind }]);
    window.setTimeout(() => setToasts((items) => items.filter((item) => item.id !== id)), 3600);
  }, []);

  const value: AppContextValue = { events, setEvents, registrations, setRegistrations, attendees, setAttendees, savedEvents, setSavedEvents, profile, setProfile, user, setUser, categoryVisibility, setCategoryVisibility, adminSettings, setAdminSettings, notify };
  return (
    <AppContext.Provider value={value}>
      {children}
      <div className="toast-stack" aria-live="polite" aria-atomic="false">
        {toasts.map((toast) => <div className={`toast toast-${toast.kind}`} key={toast.id} role={toast.kind === 'error' ? 'alert' : 'status'}><span className="toast-dot" />{toast.message}</div>)}
      </div>
    </AppContext.Provider>
  );
}

export function useApp(): AppContextValue {
  const value = useContext(AppContext);
  if (!value) throw new Error('useApp must be used within AppProvider.');
  return value;
}
