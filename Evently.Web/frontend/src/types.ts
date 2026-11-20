import type { Dispatch, SetStateAction } from "react";

export type EventStatus =
  | "upcoming"
  | "completed"
  | "draft"
  | "cancelled"
  | "archived";
export type RegistrationStatus =
  | "confirmed"
  | "pending"
  | "cancelled"
  | "rejected";
export type PaymentStatus = "Free" | "Paid" | "Pending";

export interface EventItem {
  id: string;
  title: string;
  category: string;
  date: string;
  endDate?: string;
  startTime: string;
  endTime: string;
  venue: string;
  location: string;
  address: string;
  price: number;
  ticketType: "Free" | "Paid";
  capacity: number;
  registrations: number;
  status: EventStatus;
  organizer: string;
  organizerEmail: string;
  organizerPhone: string;
  registrationDeadline?: string;
  description: string;
  objectives: string[];
  agenda: { time: string; title: string; detail: string }[];
  speakers: { name: string; role: string; initials: string }[];
  image: string;
  gallery: string[];
  featured?: boolean;
  createdAt: string;
}

export interface Registration {
  id: string;
  reference: string;
  eventId: string;
  attendeeName: string;
  email: string;
  phone: string;
  organization: string;
  attendees: number;
  requirements: string;
  registrationDate: string;
  status: RegistrationStatus;
  paymentStatus: PaymentStatus;
}

export interface Attendee {
  id: string;
  name: string;
  email: string;
  phone: string;
  organization: string;
  joined: string;
  status: "Active" | "Inactive";
}

export interface Profile {
  name: string;
  email: string;
  phone: string;
  organization: string;
  title: string;
  notifications: {
    eventUpdates: boolean;
    reminders: boolean;
    newsletter: boolean;
  };
}

export interface UserSession {
  name: string;
  email: string;
  role: "attendee" | "organizer";
}

export interface AdminSettings {
  registrations: boolean;
  newEvent: boolean;
  weeklyDigest: boolean;
  publicProfile: boolean;
}

export interface AppContextValue {
  events: EventItem[];
  setEvents: Dispatch<SetStateAction<EventItem[]>>;
  registrations: Registration[];
  setRegistrations: Dispatch<SetStateAction<Registration[]>>;
  attendees: Attendee[];
  setAttendees: Dispatch<SetStateAction<Attendee[]>>;
  savedEvents: string[];
  setSavedEvents: Dispatch<SetStateAction<string[]>>;
  profile: Profile;
  setProfile: Dispatch<SetStateAction<Profile>>;
  user: UserSession | null;
  setUser: Dispatch<SetStateAction<UserSession | null>>;
  categoryVisibility: Record<string, boolean>;
  setCategoryVisibility: Dispatch<SetStateAction<Record<string, boolean>>>;
  adminSettings: AdminSettings;
  setAdminSettings: Dispatch<SetStateAction<AdminSettings>>;
  notify: (message: string, kind?: "success" | "error" | "info") => void;
}
