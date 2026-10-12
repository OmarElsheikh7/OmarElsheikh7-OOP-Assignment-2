# Responsibilities.md

*   **AppointmentDesk**
    *   Responsibilities: Calculates business hours, manages bookings, formats ICS calendar strings, and generates SMS texts.
    *   Problem: Clinic HR business hours policy has a different stakeholder than ICS file interoperability and SMS messaging.
*   **CheckoutBasket**
    *   Responsibilities: Holds cart items, parses marketing coupons, formats gift messages, and hashes auth codes.
    *   Problem: A payment gateway integration change shouldn't risk breaking cart totaling or marketing discount logic.
*   **CourseEnrollmentDesk**
    *   Responsibilities: Manages seat capacity, runs waitlists, formats markdown packets, and calculates VAT.
    *   Problem: Financial invoice rules (VAT) have different reasons to change than markdown welcome links or seating algorithms.
*   **GradeBook**
    *   Responsibilities: Holds student scores, assigns academic letter bands, formats text transcripts, and builds CSVs.
    *   Problem: Academic policy for grading bands changes independently of plain-text registrar transcript layouts.
*   **KitchenTicket**
    *   Responsibilities: Holds food items, scans strings for allergens, estimates prep time, and formats thermal printer text.
    *   Problem: Health regulations for allergen tracking change independently of thermal printer character limits and hardware formats.
*   **LoanDesk**
    *   Responsibilities: Holds applicant data, calculates risk scores, determines compliance documents, formats letters, and exports CSVs.
    *   Problem: Underwriting math changes independently of legal document compliance rules and decision letter wording.
*   **SubscriptionBilling**
    *   Responsibilities: Holds billing dates, calculates proration, mints invoice IDs, writes dunning emails, and exports ledgers.
    *   Problem: Finance proration math should not be coupled with the legal tone of collections emails or accounting export formats.
*   **SupportTicket**
    *   Responsibilities: Holds ticket data, scans keywords for priority, computes SLAs, and formats text replies.
    *   Problem: Changing SLA breach logic shouldn't be tied to how the marketing team wants public replies to sound.
*   **WardBoard**
    *   Responsibilities: Tracks bed assignments, computes clinical acuity scores, formats handoff notes, logs pager alerts, and exports CSVs.
    *   Problem: Clinical scoring rules changing shouldn't affect administrative CSV exports or arbitrary pager thresholds.
*   **WarehousePickList**
    *   Responsibilities: Holds stock needs, allocates inventory, sorts walking paths, writes UI scripts, and builds XML.
    *   Problem: Physical warehouse layout changes (walking paths) shouldn't affect XML integration contracts with external systems.