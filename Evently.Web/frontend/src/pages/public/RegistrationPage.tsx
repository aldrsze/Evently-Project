import { useState } from 'react';
import { ArrowLeft, ArrowRight, Check, CheckCircle2, LockKeyhole, Ticket } from 'lucide-react';
import { usePath, Link } from '../../lib/router';
import { useApp } from '../../lib/app-context';
import { emailIsValid, formatDate, formatMoney, makeReference } from '../../lib/utils';
import { Field, TextAreaField, Button } from '../../components/ui';
import { imageAssets } from '../../data/events';

interface FormData { name: string; email: string; phone: string; ticket: string; attendees: string; organization: string; requirements: string }
const initialForm: FormData = { name: '', email: '', phone: '', ticket: 'standard', attendees: '1', organization: '', requirements: '' };

export default function RegistrationPage() {
  const path = usePath();
  const id = path.split('?')[0].split('/')[2];
  const { events, setEvents, setRegistrations, setProfile, user, setUser, notify } = useApp();
  const event = events.find((item) => item.id === id);
  const [step, setStep] = useState(1);
  const [form, setForm] = useState<FormData>(initialForm);
  const [errors, setErrors] = useState<Record<string, string>>({});
  const [confirmed, setConfirmed] = useState(false);
  const [reference, setReference] = useState('');
  if (!event) return <div className="page-container not-found"><h1>Event not found</h1><Link className="text-link" to="/events">Explore events</Link></div>;
  const remaining = Math.max(0, event.capacity - event.registrations);
  const deadlinePassed = Boolean(event.registrationDeadline && event.registrationDeadline < new Date().toISOString().slice(0, 10));
  const canRegister = event.status === 'upcoming' && remaining > 0 && !deadlinePassed;
  const closedTitle = event.status === 'completed' ? 'This gathering has wrapped up.' : event.status === 'cancelled' ? 'This event has been cancelled.' : remaining <= 0 ? 'This event is fully booked.' : deadlinePassed ? 'Registration has closed.' : 'Registration is not open yet.';
  const closedDescription = remaining <= 0 && event.status === 'upcoming' ? 'There are no places left for this event.' : 'You can still explore the event details or find another gathering.';
  const total = event.price * Math.max(1, Number(form.attendees || 1));
  const update = (key: keyof FormData, value: string) => { setForm((current) => ({ ...current, [key]: value })); setErrors((current) => ({ ...current, [key]: '' })); };
  const validate = (target: number) => {
    const next: Record<string, string> = {};
    if (target === 1) {
      if (!form.name.trim()) next.name = 'Please enter your name.';
      if (!emailIsValid(form.email)) next.email = 'Enter a valid email address.';
      if (form.phone.replace(/\D/g, '').length < 7) next.phone = 'Enter a valid phone number.';
    }
    if (target === 2) {
      if (!form.ticket) next.ticket = 'Choose a ticket type.';
      const count = Number(form.attendees);
      if (!Number.isInteger(count) || count < 1 || count > 8) next.attendees = 'Choose 1–8 attendees.';
      else if (count > remaining) next.attendees = `Only ${remaining} ${remaining === 1 ? 'place is' : 'places are'} available.`;
    }
    setErrors(next);
    return Object.keys(next).length === 0;
  };
  const next = () => { if (validate(step)) setStep((value) => Math.min(3, value + 1)); };
  const previous = () => setStep((value) => Math.max(1, value - 1));
  const confirm = () => {
    if (!canRegister) { notify('Registration is no longer available for this event.', 'error'); return; }
    if (!validate(1)) { setStep(1); return; }
    if (!validate(2)) { setStep(2); return; }
    if (Number(form.attendees) > remaining) { setStep(2); return; }
    const ref = makeReference();
    const registrationDate = new Date().toISOString().slice(0, 10);
    setRegistrations((current) => [{ id: `r-${Date.now()}`, reference: ref, eventId: event.id, attendeeName: form.name.trim(), email: form.email.trim(), phone: form.phone.trim(), organization: form.organization.trim() || '—', attendees: Number(form.attendees), requirements: form.requirements.trim(), registrationDate, status: 'confirmed', paymentStatus: event.price > 0 ? 'Pending' : 'Free' }, ...current]);
    setEvents((current) => current.map((item) => item.id === event.id ? { ...item, registrations: item.registrations + Number(form.attendees) } : item));
    setProfile((current) => ({ ...current, name: form.name.trim(), email: form.email.trim(), phone: form.phone.trim(), organization: form.organization.trim() || current.organization }));
    if (!user) setUser({ name: form.name.trim(), email: form.email.trim(), role: 'attendee' });
    setReference(ref); setConfirmed(true); notify('Your spot is confirmed. We’re glad you’re coming.');
  };
  if (!canRegister && !confirmed) return <section className="registration-closed page-container"><span className="eyebrow">REGISTRATION UPDATE</span><h1>{closedTitle}</h1><p>{closedDescription}</p><div className="registration-closed-actions"><Link className="button button-primary button-md" to={`/events/${event.id}`}>View event details</Link><Link className="button button-secondary button-md" to="/events">Explore other events</Link></div></section>;
  if (confirmed) return <section className="registration-success page-container"><div className="success-mark"><CheckCircle2 size={34} /></div><span className="eyebrow">IT’S A PLAN</span><h1>You’re on the list.</h1><p className="success-intro">We saved your spot for <strong>{event.title}</strong>. Your reference number is below.</p><div className="reference-ticket"><div className="reference-ticket-top"><div><span>YOUR REFERENCE</span><strong>{reference}</strong></div><span className="reference-status"><Check size={13} /> CONFIRMED</span></div><div className="reference-ticket-bottom"><span>{formatDate(event.date, { month: 'short', day: 'numeric' })} · {event.startTime}</span><span>{event.location}</span></div></div><p className="simulation-note">This is a frontend demonstration. No email or payment was processed.</p><div className="success-actions"><Link className="button button-primary button-md" to="/dashboard/registrations">View my registrations <ArrowRight size={16} /></Link><Link className="button button-secondary button-md" to="/events">Explore more events</Link></div></section>;
  return <div className="registration-page"><div className="registration-top page-container"><Link to={`/events/${event.id}`} className="back-link"><ArrowLeft size={15} />Back to event</Link><div className="registration-trust"><LockKeyhole size={14} /> Simple, secure registration</div></div><div className="registration-shell page-container"><div className="registration-main"><span className="eyebrow">Save your seat</span><h1>You're almost there.</h1><p className="registration-intro">A few details, then the good part.</p><div className="progress-track" aria-label={`Step ${step} of 3`}>{[1, 2, 3].map((item) => <div key={item} className={`progress-step ${step >= item ? 'is-current' : ''}`}><span>{step > item ? <Check size={14} /> : item}</span><strong>{['Your details', 'The plan', 'Review'][item - 1]}</strong></div>)}</div>
    {step === 1 && <section className="registration-form-step"><h2>Who’s joining us?</h2><p>We’ll use these details to hold your spot.</p><Field label="Full name" name="name" autoComplete="name" requiredMark value={form.name} onChange={(event) => update('name', event.target.value)} error={errors.name} placeholder="Your name" /><Field label="Email address" name="email" type="email" autoComplete="email" requiredMark value={form.email} onChange={(event) => update('email', event.target.value)} error={errors.email} placeholder="you@example.com" /><Field label="Phone number" name="phone" type="tel" autoComplete="tel" requiredMark value={form.phone} onChange={(event) => update('phone', event.target.value)} error={errors.phone} placeholder="+63 917 000 0000" helper="Only used if we need to reach you about the event." /></section>}
    {step === 2 && <section className="registration-form-step"><h2>Make it your kind of day.</h2><p>Let us know who you’re bringing and what you need.</p><div className="field-group"><div className="field-label-row"><label>Ticket type <span className="required-star">*</span></label>{errors.ticket && <span className="field-error">{errors.ticket}</span>}</div><label className={`ticket-choice ${form.ticket === 'standard' ? 'ticket-choice-selected' : ''}`}><input type="radio" name="ticket-type" value="standard" checked={form.ticket === 'standard'} onChange={(event) => update('ticket', event.target.value)} /><span className="ticket-choice-icon"><Ticket size={17} /></span><span><strong>{event.price ? 'General admission' : 'Community ticket'}</strong><small>{event.price ? 'Full event access' : 'A place at the gathering'}</small></span><strong className="ticket-choice-price">{formatMoney(event.price)}</strong></label>{event.price > 0 && <label className={`ticket-choice ${form.ticket === 'supporter' ? 'ticket-choice-selected' : ''}`}><input type="radio" name="ticket-type" value="supporter" checked={form.ticket === 'supporter'} onChange={(event) => update('ticket', event.target.value)} /><span className="ticket-choice-icon"><CheckCircle2 size={17} /></span><span><strong>Supporter ticket</strong><small>Help keep community events welcoming</small></span><strong className="ticket-choice-price">{formatMoney(event.price + 150)}</strong></label>}<div className="field-grid"><Field label="Number of attendees" name="attendees" type="number" min="1" max="8" requiredMark value={form.attendees} onChange={(event) => update('attendees', event.target.value)} error={errors.attendees} /><Field label="Organization or institution" name="organization" value={form.organization} onChange={(event) => update('organization', event.target.value)} placeholder="Optional" /></div><TextAreaField label="Special requirements" value={form.requirements} onChange={(event) => update('requirements', event.target.value)} rows={3} placeholder="Access, dietary needs, or anything else we should know" helper="Optional. Only visible to the event organizer." /></div></section>}
    {step === 3 && <section className="registration-form-step"><h2>One last look.</h2><p>Check the details before you make it official.</p><div className="review-event"><img src={event.image || imageAssets.hero} alt="" /><div><span>{formatDate(event.date, { month: 'long', day: 'numeric' })} · {event.startTime}</span><strong>{event.title}</strong><small>{event.location}</small></div></div><div className="review-block"><div><span>ATTENDEE</span><strong>{form.name}</strong><small>{form.email} · {form.phone}</small></div><button className="review-edit" onClick={() => setStep(1)}>Edit</button></div><div className="review-block"><div><span>REGISTRATION</span><strong>{form.ticket === 'supporter' ? 'Supporter ticket' : event.price ? 'General admission' : 'Community ticket'} · {form.attendees} {Number(form.attendees) === 1 ? 'person' : 'people'}</strong><small>{form.organization || 'No organization added'}{form.requirements ? ` · ${form.requirements}` : ''}</small></div><button className="review-edit" onClick={() => setStep(2)}>Edit</button></div><div className="review-total"><span>Total {event.price ? '(mock total)' : ''}</span><strong>{formatMoney(form.ticket === 'supporter' ? (event.price + 150) * Number(form.attendees) : total)}</strong></div><p className="simulation-note">Frontend demo only. No payment details are collected or charged.</p></section>}
    <div className="registration-step-actions">{step > 1 && <Button variant="secondary" onClick={previous}><ArrowLeft size={15} /> Back</Button>}{step < 3 ? <Button onClick={next}>Continue <ArrowRight size={15} /></Button> : <Button onClick={confirm}>Confirm registration <ArrowRight size={15} /></Button>}</div>
    </div><aside className="registration-summary"><div className="summary-photo"><img src={event.image} alt="" /></div><span className="eyebrow">YOU’RE JOINING</span><h2>{event.title}</h2><div className="summary-fact"><span>{formatDate(event.date, { month: 'long', day: 'numeric', year: 'numeric' })}</span><span>{event.startTime} – {event.endTime}</span></div><div className="summary-fact"><span>{event.venue}</span><span>{event.location}</span></div><div className="summary-divider" /><div className="summary-price"><span>Admission</span><strong>{formatMoney(event.price)}</strong></div>{step > 1 && <div className="summary-price"><span>Attendees</span><strong>{form.attendees}</strong></div>}<div className="summary-total"><span>Total</span><strong>{formatMoney(form.ticket === 'supporter' ? (event.price + 150) * Number(form.attendees) : total)}</strong></div><div className="summary-footnote"><LockKeyhole size={14} /><span>Simple, secure, and no payment details collected.</span></div></aside></div></div>;
}
