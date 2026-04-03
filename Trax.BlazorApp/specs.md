# Trax - Donation Tracking Application

## Overview
Trax is a web application for tracking the donation, warehousing, and distribution of domestic household items to organizations in need.

## Core Features
- Track incoming donations of household items and manage warehouse inventory
- Track distribution of items to organizations in need
- Generate reports and monitor inventory levels
- Manage volunteers who assist with pickups and deliveries
- Schedule pickups and deliveries, with volunteer sign-up for tasks

## Tech Stack
- **Frontend:** Blazor (C#) with MudBlazor UI framework
- **Database:** Supabase (PostgreSQL, database name: `trax`)
- **ORM:** Entity Framework Core 9 with Npgsql provider
- **Auth:** Supabase Auth + Google OAuth 2.0
- **Design:** Responsive, user-friendly, clean and modern interface

## Architecture
The application follows **Clean Architecture** with the following layers and patterns:

### Project Structure
```
Trax.Domain        - Entities, enums, interfaces, base specification
Trax.Application   - Services, use-case interfaces, specifications
Trax.Infrastructure - EF Core DbContext, repository implementations, data seeding
Trax.Database      - Console app for deploying EF Core migrations to Supabase
Trax.BlazorApp     - Blazor Server UI (references Application + Infrastructure)
```

### Patterns
- **Repository Pattern** — `IRepository<T>` abstraction over EF Core, registered as open generic
- **Specification Pattern** — `ISpecification<T>` / `BaseSpecification<T>` for composable, reusable queries
- **Dependency Inversion** — UI and Application layers depend only on abstractions defined in Domain

### Database Project (`Trax.Database`)
- Standalone console app used to deploy and manage the Supabase schema
- Acts as the single source of truth for database structure via EF Core migrations
- Supports `dotnet ef migrations add`, `dotnet ef database update`, and SQL script generation
- Contains a `DesignTimeDbContextFactory` for tooling support

### Data Seeding
- `ItemCategory` seed data (Furniture, Appliances, Clothing, Electronics, etc.) applied on first run
- Super Admin user (`tom.c.christensen@gmail.com`) seeded at startup if not present

## User Roles & Authentication
- Define roles: Super Admin, Admin, Volunteer, Organization, Donor
- Login/registration flow (Supabase Auth)
- Google OAuth 2.0 sign-in via Supabase Auth provider
- Role-based access control (who can see/do what)

### Super Admin
- `tom.c.christensen@gmail.com` is the designated Super Admin 
- Super Admin account is seeded at startup and cannot be deleted or demoted
- Super Admin can grant and revoke any role to any Google-authenticated user
- Super Admin has full access to all application features and data

### Role Assignment
- Super Admin and Admins can assign roles (Volunteer, Organization, Donor) to other users
- Only the Super Admin can promote or demote Admins
- New users who sign in via Google are assigned no role by default and must be granted access by an Admin or Super Admin

## Data Models
- Donation: item name, category, condition, quantity, donor info, date received, status
- Item Category: furniture, appliances, clothing, etc.
- Organization: name, contact, address, needs/requests
- Volunteer: name, contact, availability, assigned tasks
- Pickup/Delivery: scheduled date, location, assigned volunteer, status

## Inventory Management
- Item status lifecycle: Donated → Received → Warehoused → Reserved → Delivered
- Low inventory alerts
- Item condition tracking (new, good, fair, poor)

## Scheduling & Notifications
- Email/SMS notifications for pickup confirmations
- Volunteer schedule conflicts/availability windows
- Calendar view for upcoming pickups and deliveries

## Reporting
- Inventory summary by category
- Donation history by donor or date range
- Volunteer hours/activity log
- Items distributed per organization

## Non-Functional Requirements
- Mobile responsiveness
- Offline/PWA support (if needed)
- Performance expectations (page load, concurrent users)
- Data retention/archival policy

## Integrations
- Supabase Realtime for live inventory updates
- Map/geolocation for pickup addresses
- Export to CSV/PDF for reports

## Future Considerations
- Donor-facing portal to track their donation
- Public wishlist for organizations to post needs