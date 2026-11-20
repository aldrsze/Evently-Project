import { useState } from 'react';
import { ArrowLeft, ArrowRight, Bookmark, CalendarDays, Check, Clock3, Copy, MapPin, Share2, ShieldCheck, Ticket, UsersRound } from 'lucide-react';
import { Link, usePath } from '../../lib/router';
import { useApp } from '../../lib/app-context';
import { formatDate, formatMoney, seatsLeft } from '../../lib/utils';
import { EventGrid } from '../../components/EventCard';
import { Badge, Button, EmptyState } from '../../components/ui';

export default function EventDetailPage() {
  const path = usePath();
  const id = path.split('?')[0].split('/')[2];
  const { events, savedEvents, setSavedEvents, notify, adminSettings } = useApp();
  const [tab, setTab] = useState<'about' | 'schedule'>('about');
  const event = events.find((item) => item.id === id);
  if (!event) return <div className="page-container not-found"><EmptyState title="We couldn't find that gathering." description="It may have moved, but there are more good things to discover." action={<Link className="button button-primary button-md" to="/events">Explore events</Link>} /></div>;

  const saved = savedEvents.includes(event.id);
  const related = events.filter((item) => item.id !== event.id && item.status === 'upcoming' && (item.category === event.category || item.location.split(',')[0] === event.location.split(',')[0])).slice(0, 3);
  const remaining = seatsLeft(event);
  const deadlinePassed = Boolean(event.registrationDeadline && event.registrationDeadline < new Date().toISOString().slice(0, 10));
  const unavailable = event.status !== 'upcoming' || remaining <= 0 || deadlinePassed;
  const unavailableLabel = event.status === 'completed' ? 'Event complete' : event.status === 'cancelled' ? 'Event cancelled' : event.status === 'draft' ? 'Registration coming soon' : remaining <= 0 ? 'Sold out' : 'Registration closed';

  const save = () => {
    setSavedEvents((current) => saved ? current.filter((item) => item !== event.id) : [...current, event.id]);
    notify(saved ? 'Removed from saved events.' : 'Saved for later.');
  };
  const share = async () => {
    const url = new URL(`/events/${event.id}`, window.location.href).toString();
    if (navigator.share) {
      try { await navigator.share({ title: event.title, text: `Join me at ${event.title}`, url }); }
      catch { /* A dismissed share sheet is not an error. */ }
    } else if (navigator.clipboard) {
      try { await navigator.clipboard.writeText(url); notify('Event link copied to your clipboard.'); }
      catch { notify('Copy this page address to share the event.', 'info'); }
    } else notify('Copy this page address to share the event.', 'info');
  };
  const copy = async () => {
    try {
      if (!navigator.clipboard) throw new Error('Clipboard unavailable');
      await navigator.clipboard.writeText(new URL(`/events/${event.id}`, window.location.href).toString());
      notify('Event link copied to your clipboard.');
    } catch { notify('Copy this page address to share the event.', 'info'); }
  };

  return <div className="event-detail-page"><div className="page-container event-detail-container">
    <Link to="/events" className="back-link"><ArrowLeft size={15} />All events</Link>
    <div className="detail-cover"><img src={event.image} alt={`${event.title} at ${event.venue}`} /><div className="detail-cover-shade" /><div className="detail-cover-caption"><Badge tone="slate">{event.category}</Badge><span>EVENTLY · {event.location.split(',')[0].toUpperCase()}</span></div></div>
    <div className="event-detail-layout"><main className="event-detail-main">
      <div className="detail-title-row"><div><div className="eyebrow">{adminSettings.publicProfile ? `${event.organizer} presents` : 'An Evently gathering'}</div><h1>{event.title}</h1></div><div className="detail-actions"><button onClick={save} className={`detail-icon-action ${saved ? 'is-saved' : ''}`} aria-pressed={saved}><Bookmark size={17} fill={saved ? 'currentColor' : 'none'} /><span>{saved ? 'Saved' : 'Save'}</span></button><button onClick={share} className="detail-icon-action"><Share2 size={17} /><span>Share</span></button><button onClick={copy} className="detail-icon-action detail-copy"><Copy size={16} /><span>Copy link</span></button></div></div>
      <div className="detail-facts"><div><span className="detail-fact-icon"><CalendarDays size={18} /></span><div><span>WHEN</span><strong>{formatDate(event.date, { month: 'long', day: 'numeric', year: 'numeric' })}</strong><small>{event.startTime} – {event.endTime}</small></div></div><div><span className="detail-fact-icon"><MapPin size={18} /></span><div><span>WHERE</span><strong>{event.venue}</strong><small>{event.location}</small></div></div><div><span className="detail-fact-icon"><Ticket size={18} /></span><div><span>ADMISSION</span><strong>{formatMoney(event.price)}</strong><small>{event.price ? 'per person' : 'Everyone is welcome'}</small></div></div></div>
      <div className="detail-tabs" role="tablist" aria-label="Event information"><button className={tab === 'about' ? 'active' : ''} role="tab" aria-selected={tab === 'about'} onClick={() => setTab('about')}>About</button><button className={tab === 'schedule' ? 'active' : ''} role="tab" aria-selected={tab === 'schedule'} onClick={() => setTab('schedule')}>Schedule</button></div>
      {tab === 'about' ? <section className="detail-body" role="tabpanel"><h2>A gathering for people who care.</h2><p>{event.description}</p><p>Come as you are. You’ll find an open door, thoughtful hosts, and a little room to let curiosity take the lead. Whether you arrive with a friend or on your own, you’ll be in good company.</p><div className="detail-objectives"><h3>A little of what to expect</h3>{event.objectives.map((objective) => <div key={objective}><span><Check size={14} /></span>{objective}</div>)}</div><div className="detail-speakers"><h3>Meet your hosts</h3><div className="speaker-grid">{event.speakers.map((speaker, index) => <div className="speaker-row" key={speaker.name}><div className={`avatar ${index ? 'avatar-peach' : 'avatar-purple'}`}>{speaker.initials}</div><div><strong>{speaker.name}</strong><span>{speaker.role}</span></div></div>)}</div></div></section> : <section className="detail-body" role="tabpanel"><h2>A day with a little shape.</h2><div className="agenda-list">{event.agenda.map((item, index) => <article className="agenda-item" key={item.time}><span className="agenda-time">{item.time}</span><span className="agenda-dot" /><div><h3>{item.title}</h3><p>{item.detail}</p></div>{index === 0 && <Clock3 size={15} />}</article>)}</div></section>}
      {adminSettings.publicProfile && <div className="detail-organizer"><div className="organizer-avatar">{event.organizer.split(' ').map((part) => part[0]).slice(0, 2).join('')}</div><div><span>HOSTED BY</span><strong>{event.organizer}</strong><small>Thoughtfully bringing people together since 2022.</small></div><Link className="text-link" to="/contact">Contact host <ArrowRight size={14} /></Link></div>}
    </main><aside className="registration-card"><div className="registration-card-label"><span>MAKE IT A PLAN</span><span className="availability-dot" />{remaining > 0 ? `${remaining} spots left` : 'No spots available'}</div><div className="registration-price">{formatMoney(event.price)}{event.price > 0 && <small> / person</small>}</div><p className="registration-card-text">{event.price === 0 ? 'A good time, on us. Reserve a spot for you or a friend.' : 'One simple registration. Everything you need to know, up front.'}</p>{!unavailable ? <Link className="button button-primary button-full" to={`/register/${event.id}`}>Register now <ArrowRight size={16} /></Link> : <Button disabled className="button-full">{unavailableLabel}</Button>}<div className="registration-assurance"><ShieldCheck size={16} /><span>Secure your place in just a few steps.</span></div><div className="registration-mini-facts"><div><UsersRound size={16} /><span>{event.registrations} people are going</span></div><div><MapPin size={16} /><span>{event.address}</span></div></div><button className="copy-link-inline" onClick={copy}><Copy size={14} />Copy event link</button></aside></div>
    {event.gallery?.length > 0 && <section className="event-gallery" aria-label="Event image gallery"><div className="section-heading"><div><span className="eyebrow">A closer look</span><h2>Scenes from the gathering.</h2></div></div><div className="event-gallery-grid">{event.gallery.map((image, index) => <img key={`${image}-${index}`} src={image} alt={`${event.title} gallery view ${index + 1}`} loading="lazy" />)}</div></section>}
    {related.length > 0 && <section className="related-events"><div className="section-heading"><div><span className="eyebrow">More like this</span><h2>Keep a little room in your calendar.</h2></div><Link className="text-link" to="/events">All events <ArrowRight size={15} /></Link></div><EventGrid items={related} /></section>}
  </div></div>;
}
