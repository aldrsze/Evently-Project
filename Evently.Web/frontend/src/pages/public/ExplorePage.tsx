import { useEffect, useMemo, useState } from 'react';
import { ArrowRight, CalendarDays, ChevronDown, Filter, MapPin, Search, SlidersHorizontal, X } from 'lucide-react';
import { Link, usePath } from '../../lib/router';
import { useApp } from '../../lib/app-context';
import { categories } from '../../data/events';
import { EventGrid } from '../../components/EventCard';
import { Badge, Button, EmptyState } from '../../components/ui';

export default function ExplorePage() {
  const { events, categoryVisibility } = useApp();
  const path = usePath();
  const query = new URLSearchParams(path.split('?')[1] ?? '');
  const [term, setTerm] = useState(query.get('q') ?? '');
  const [category, setCategory] = useState(query.get('category') ?? '');
  const visibleCategories = categories.filter((item) => categoryVisibility[item.name] !== false || item.name === category);
  const [location, setLocation] = useState(query.get('location') ?? '');
  const [price, setPrice] = useState('all');
  const [dateRange, setDateRange] = useState('any');
  const [sort, setSort] = useState('soonest');
  const [showMore, setShowMore] = useState(6);
  const [showFilters, setShowFilters] = useState(false);
  const [loading, setLoading] = useState(true);
  useEffect(() => {
    const timer = window.setTimeout(() => setLoading(false), 280);
    return () => window.clearTimeout(timer);
  }, [term, category, location, price, dateRange, sort]);
  const visibleEvents = useMemo(() => {
    const now = new Date();
    let list = events.filter((item) => item.status === 'upcoming');
    if (term.trim()) list = list.filter((item) => `${item.title} ${item.description} ${item.category}`.toLowerCase().includes(term.trim().toLowerCase()));
    if (category) list = list.filter((item) => item.category === category);
    if (location.trim()) list = list.filter((item) => item.location.toLowerCase().includes(location.trim().toLowerCase()));
    if (price === 'free') list = list.filter((item) => item.price === 0);
    if (price === 'paid') list = list.filter((item) => item.price > 0);
    if (dateRange === 'week') { const end = new Date(); end.setDate(now.getDate() + 7); list = list.filter((item) => new Date(item.date) <= end); }
    if (dateRange === 'month') list = list.filter((item) => new Date(item.date).getMonth() === now.getMonth() && new Date(item.date).getFullYear() === now.getFullYear());
    if (dateRange === 'quarter') { const end = new Date(); end.setMonth(now.getMonth() + 3); list = list.filter((item) => new Date(item.date) <= end); }
    if (sort === 'soonest') list = [...list].sort((a, b) => a.date.localeCompare(b.date));
    if (sort === 'latest') list = [...list].sort((a, b) => b.date.localeCompare(a.date));
    if (sort === 'price-low') list = [...list].sort((a, b) => a.price - b.price);
    if (sort === 'price-high') list = [...list].sort((a, b) => b.price - a.price);
    return list;
  }, [events, term, category, location, price, dateRange, sort]);
  const clear = () => { setTerm(''); setCategory(''); setLocation(''); setPrice('all'); setDateRange('any'); setSort('soonest'); setShowMore(6); };
  const activeCount = [term, category, location, price !== 'all', dateRange !== 'any'].filter(Boolean).length;
  const removeFilter = (key: string) => {
    if (key === 'term') setTerm('');
    if (key === 'category') setCategory('');
    if (key === 'location') setLocation('');
    if (key === 'price') setPrice('all');
    if (key === 'date') setDateRange('any');
  };
  const featured = events.find((item) => item.featured && item.status === 'upcoming') ?? events[0];
  return <div className="explore-page"><section className="explore-hero"><div className="page-container"><div className="eyebrow">Find your next favorite</div><h1>Good things are <em>happening.</em></h1><p>A good event can change the shape of a day. Find yours.</p><form className="explore-search" onSubmit={(event) => event.preventDefault()}><Search size={18} /><label className="sr-only" htmlFor="explore-search">Search events</label><input id="explore-search" value={term} onChange={(event) => { setTerm(event.target.value); setShowMore(6); }} placeholder="Search events, topics, or interests..." /><span className="search-key">⌘ K</span></form></div></section>
    <section className="page-container explore-body"><Link to={`/events/${featured.id}`} className="explore-featured"><img src={featured.image} alt="" /><div className="explore-featured-overlay" /><div className="featured-copy"><Badge tone="slate">A little something special</Badge><h2>{featured.title}</h2><p><CalendarDays size={15} />{new Intl.DateTimeFormat('en-US', { month: 'long', day: 'numeric' }).format(new Date(`${featured.date}T12:00:00`))}<span>·</span><MapPin size={15} />{featured.location}</p><span className="featured-arrow">Discover the event <ArrowRight size={16} /></span></div><span className="featured-side-note">EVENTLY PICKS · 01</span></Link>
    <div className="explore-toolbar"><div className="explore-filter-toggle"><Button variant="secondary" onClick={() => setShowFilters((value) => !value)} icon={<SlidersHorizontal size={16} />}>Filters{activeCount > 0 && <span className="filter-count">{activeCount}</span>}<ChevronDown size={15} /></Button><span className="result-count">{visibleEvents.length} {visibleEvents.length === 1 ? 'event' : 'events'} worth a look</span></div><label className="sort-control"><span>Sort by</span><select aria-label="Sort events" value={sort} onChange={(event) => setSort(event.target.value)}><option value="soonest">Soonest</option><option value="latest">Furthest away</option><option value="price-low">Price: low to high</option><option value="price-high">Price: high to low</option></select></label></div>
    <div className={`filter-panel ${showFilters ? 'filter-panel-open' : ''}`}><div className="filter-group"><label htmlFor="filter-category">Category</label><select id="filter-category" value={category} onChange={(event) => { setCategory(event.target.value); setShowMore(6); }}><option value="">All categories</option>{visibleCategories.map((item) => <option key={item.name} value={item.name}>{item.name}</option>)}</select></div><div className="filter-group"><label htmlFor="filter-date">When</label><select id="filter-date" value={dateRange} onChange={(event) => setDateRange(event.target.value)}><option value="any">Any date</option><option value="week">Next 7 days</option><option value="month">This month</option><option value="quarter">Next 3 months</option></select></div><div className="filter-group"><label htmlFor="filter-location">Location</label><div className="filter-input-wrap"><MapPin size={15} /><input id="filter-location" value={location} onChange={(event) => setLocation(event.target.value)} placeholder="City or region" /></div></div><div className="filter-group"><label htmlFor="filter-price">Price</label><select id="filter-price" value={price} onChange={(event) => setPrice(event.target.value)}><option value="all">Any price</option><option value="free">Free events</option><option value="paid">Paid events</option></select></div></div>
    {activeCount > 0 && <div className="active-filters"><span>Applied:</span>{term && <button onClick={() => removeFilter('term')}>“{term}” <X size={12} /></button>}{category && <button onClick={() => removeFilter('category')}>{category} <X size={12} /></button>}{location && <button onClick={() => removeFilter('location')}>{location} <X size={12} /></button>}{price !== 'all' && <button onClick={() => removeFilter('price')}>{price === 'free' ? 'Free' : 'Paid'} <X size={12} /></button>}{dateRange !== 'any' && <button onClick={() => removeFilter('date')}>{dateRange === 'week' ? 'Next 7 days' : dateRange === 'month' ? 'This month' : 'Next 3 months'} <X size={12} /></button>}<button className="clear-filters" onClick={clear}>Clear all</button></div>}
    {loading ? <div className="event-grid">{Array.from({ length: 3 }, (_, index) => <div className="event-skeleton" key={index}><div /><span /><span /><span /></div>)}</div> : visibleEvents.length ? <><EventGrid items={visibleEvents.slice(0, showMore)} /><div className="load-more-row"><span>Showing {Math.min(showMore, visibleEvents.length)} of {visibleEvents.length}</span>{showMore < visibleEvents.length && <Button variant="secondary" onClick={() => setShowMore((count) => count + 6)}>Load more events <ArrowRight size={15} /></Button>}</div></> : <EmptyState icon={<Filter size={22} />} title="No events found this time." description="Try a different search or clear a filter to see what’s happening." action={<Button variant="secondary" onClick={clear}>Clear all filters</Button>} />}
    <section className="organizer-callout"><div><span className="eyebrow">Have something in mind?</span><h2>Bring your people together.</h2><p>Create a thoughtful, welcoming space for your community.</p></div><Link className="button button-dark button-md" to="/admin/events/new">Host an event <ArrowRight size={16} /></Link></section></section></div>;
}
