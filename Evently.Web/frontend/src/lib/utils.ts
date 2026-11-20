import type { EventItem } from '../types';

export function formatDate(value: string, options: Intl.DateTimeFormatOptions = { month: 'short', day: 'numeric', year: 'numeric' }): string {
  return new Intl.DateTimeFormat('en-US', options).format(new Date(`${value}T12:00:00`));
}

export function formatShortDate(value: string): { month: string; day: string; weekday: string } {
  const date = new Date(`${value}T12:00:00`);
  return {
    month: new Intl.DateTimeFormat('en-US', { month: 'short' }).format(date).toUpperCase(),
    day: new Intl.DateTimeFormat('en-US', { day: '2-digit' }).format(date),
    weekday: new Intl.DateTimeFormat('en-US', { weekday: 'short' }).format(date),
  };
}

export function formatMoney(amount: number): string {
  return amount === 0 ? 'Free' : new Intl.NumberFormat('en-PH', { style: 'currency', currency: 'PHP', maximumFractionDigits: 0 }).format(amount);
}

export function seatsLeft(item: EventItem): number {
  return Math.max(0, item.capacity - item.registrations);
}

export function emailIsValid(value: string): boolean {
  return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(value.trim());
}

export function makeReference(): string {
  return `EV-${new Date().getFullYear().toString().slice(-2)}-${Math.random().toString(36).slice(2, 7).toUpperCase()}`;
}

export function downloadCsv(filename: string, rows: string[][]): void {
  const csv = rows.map((row) => row.map((cell) => `"${String(cell).replaceAll('"', '""')}"`).join(',')).join('\r\n');
  const link = document.createElement('a');
  link.href = URL.createObjectURL(new Blob([csv], { type: 'text/csv;charset=utf-8;' }));
  link.download = filename;
  link.click();
  URL.revokeObjectURL(link.href);
}

export function initials(name: string): string {
  return name.split(/\s+/).filter(Boolean).slice(0, 2).map((part) => part[0]).join('').toUpperCase();
}
