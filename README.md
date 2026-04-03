# Trax - Donation Tracking Application

> A web application for tracking the donation, warehousing, and distribution of domestic household items to organizations in need.

---

## Overview

Trax helps manage the full lifecycle of donated household items — from intake and warehousing to distribution. It also coordinates volunteers for pickups and deliveries, supports scheduling, and provides reporting tools for admins and organizations.

---

## Core Features

- Track incoming donations of household items and manage warehouse inventory
- Track distribution of items to organizations in need
- Generate reports and monitor inventory levels
- Manage volunteers who assist with pickups and deliveries
- Schedule pickups and deliveries, with volunteer sign-up for tasks

---

## Tech Stack

| Layer    | Technology                          |
|----------|-------------------------------------|
| Frontend | Blazor (C#) with MudBlazor UI       |
| Database | Supabase (PostgreSQL + Realtime)    |
| Auth     | Supabase Auth + Google OAuth 2.0   |
| Platform | .NET 10                             |

---

## User Roles

| Role        | Description                                              |
|-------------|----------------------------------------------------------|
| Super Admin | Full access; seeds the system; manages all roles         |
| Admin       | Can assign Volunteer, Organization, and Donor roles      |
| Volunteer   | Signs up for and completes pickup/delivery tasks         |
| Organization| Receives donated items; can post item requests           |
| Donor       | Submits donations; can track their donation status       |

> **Super Admin:** `tom.c.christensen@gmail.com` — seeded at startup, cannot be deleted or demoted.  
> New Google sign-ins have no role by default and must be granted access by an Admin or Super Admin.

---

## Data Models

- **Donation** — item name, category, condition, quantity, donor info, date received, status
- **Item Category** — furniture, appliances, clothing, etc.
- **Organization** — name, contact, address, needs/requests
- **Volunteer** — name, contact, availability, assigned tasks
- **Pickup/Delivery** — scheduled date, location, assigned volunteer, status

---

## Inventory Management

- Item status lifecycle: `Donated → Received → Warehoused → Reserved → Delivered`
- Low inventory alerts
- Item condition tracking: New, Good, Fair, Poor

---

## Scheduling & Notifications

- Email/SMS notifications for pickup confirmations
- Volunteer availability windows and conflict detection
- Calendar view for upcoming pickups and deliveries

---

## Reporting

- Inventory summary by category
- Donation history by donor or date range
- Volunteer hours and activity log
- Items distributed per organization

---

## Integrations

- Supabase Realtime for live inventory updates
- Map/geolocation for pickup addresses
- Export to CSV/PDF for reports

---

## Future Considerations

- Donor-facing portal to track their donation
- Public wishlist for organizations to post needs
- Offline/PWA support

---

## Getting Started

> Prerequisites: .NET 10 SDK, a Supabase project, Google OAuth credentials

1. Clone the repo
   ```bash
   git clone https://github.com/tchristc/Trax.git
   ```
2. Configure Supabase and Google OAuth credentials in `appsettings.json`
3. Run the application
   ```bash
   dotnet run --project Trax.BlazorApp
   ```
