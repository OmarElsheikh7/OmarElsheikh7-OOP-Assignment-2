using SrpLab.srpLabRefactor; // Make sure this matches the namespace of your new classes

Console.WriteLine("SrpLab — Refactored Runner");
Console.WriteLine("=================================================");

// --- 1. Ward Board ---
var census = new WardCensus();
var scorer = new AcuityScorer();
var pager = new PagerNotifier();
var handoffFormatter = new HandoffNoteFormatter();

var acuity = scorer.Score(130, 89);
census.AssignBed(1, "p-88");
pager.CheckAndAlert(1, acuity);

Console.WriteLine(handoffFormatter.BuildNote(1, census.BedPatient[1], acuity));
Console.WriteLine(string.Join(" | ", pager.Log));


// --- 2. Checkout Basket ---
var cart = new CartTotals();
cart.AddLine("SKU-1", 40m, 2);

var coupons = new CouponEvaluator();
var discount = coupons.DiscountAmount(cart.SubTotal(), "SAVE10");
var grandTotal = cart.SubTotal() - discount + 4.99m; // 4.99 added for gift wrap

var payment = new PaymentGatewaySimulator();
Console.WriteLine($"basket total={grandTotal} auth={payment.AuthorizePaymentStub(grandTotal, "4242", cart.Lines.Count)}");


// --- 3. Support Ticket ---
var ticketData = new SupportTicketData("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow);
var priorityAnalyzer = new TicketPriorityAnalyzer();
var priority = priorityAnalyzer.AnalyzePriority(ticketData.Subject, ticketData.Body);

var slaCalc = new SlaCalculator();
var deadline = slaCalc.Deadline(ticketData.OpenedAt, priority);

var ticketComms = new TicketCommsFormatter();
Console.WriteLine(ticketComms.DraftPublicReply(ticketData.Id, priority, "Nora", deadline));


// --- 4. Loan Desk ---
var app = new LoanApplication(60_000m, 640, 4, HasCollateral: false);
var underwriter = new LoanUnderwriter();
var risk = underwriter.RiskScore(app);
var isEligible = underwriter.IsEligible(risk, app.CreditScore);

var compliance = new ComplianceChecklist();
var docs = compliance.RequiredDocuments(app, isEligible);

var letterGen = new DecisionLetterGenerator();
Console.WriteLine(letterGen.DecisionLetter("Omar", app.Amount, risk, isEligible, docs));


// --- 5. Course Enrollment ---
var roster = new CourseRoster(capacity: 1);
Console.WriteLine(roster.Register("a@mail.com"));
Console.WriteLine(roster.Register("b@mail.com"));

var welcomeGen = new WelcomePacketGenerator();
var studentStatus = roster.IsSeated("b@mail.com") ? "confirmed seat" : $"waitlist #{roster.WaitlistPosition("b@mail.com")}";
Console.WriteLine(welcomeGen.WelcomePacketMarkdown("SEF-101", "Bea", studentStatus));


// --- 6. Kitchen Ticket ---
var order = new KitchenOrder();
order.AddItem("Pasta", new[] { "wheat", "milk" }, 12);

var allergenDetector = new AllergenDetector();
var allergens = allergenDetector.DetectAllergens(order);

var timeEstimator = new PrepTimeEstimator();
var eta = timeEstimator.EstimatedReadyMinutes(order, stations: 2, hasAllergens: allergens.Count > 0);

var thermalPrinter = new ThermalTicketPrinter();
Console.WriteLine(thermalPrinter.RenderThermalTicket(order, 42, eta, allergens));


// --- 7. Subscription Billing ---
var start = new DateOnly(2026, 9, 1);
var end = new DateOnly(2026, 10, 1);
var price = 99m;

var proration = new ProrationCalculator();
var amount = proration.Prorate(start, end, start, price); // original logic prorated from PeriodStart

var invoiceGen = new InvoiceNumberGenerator();
var invoice = invoiceGen.Next(start);

int failedPayments = 1; // Simulated increment
var dunningFormatter = new DunningEmailFormatter();
Console.WriteLine(dunningFormatter.DunningEmail("Sara", new DateOnly(2026, 9, 20), amount, invoice, failedPayments));


// --- 8. Warehouse Pick List ---
var reqs = new PickListRequirements();
reqs.AddNeed("BOLT", "A", 3, 10, 7);
reqs.AddNeed("NUT", "B", 1, 5, 5);

var router = new WalkingPathRouter();
var path = router.Order(reqs);

var allocator = new InventoryAllocator();
var allocations = allocator.Allocate(reqs);
var shortages = allocations.Where(a => a.Allocated < reqs.Lines.First(l => l.Sku == a.Sku).Needed).Select(a => a.Sku);

var scriptGen = new PickerScriptGenerator();
Console.WriteLine(scriptGen.PickerScript(path, shortages));


// --- 9. Grade Book ---
var scores = new StudentScores();
scores.Record("s1", 92);
scores.Record("s1", 88);

var policy = new AcademicPolicyEvaluator();
var avg = scores.Average("s1");
var letter = policy.Letter(avg);
var honor = policy.MeetsHonorRoll(avg, letter);

var transcript = new TranscriptPrinter();
Console.WriteLine(transcript.TranscriptPlain("s1", "Ali", avg, letter, honor));


// --- 10. Appointment Desk ---
var schedule = new ClinicSchedule(new TimeOnly(9, 0), new TimeOnly(17, 0), slotMinutes: 30);
var from = DateTimeOffset.Parse("2026-09-21T08:00:00Z");
var searchEnd = from.AddHours(48);
var cursor = schedule.Align(from);
DateTimeOffset? bookedSlot = null;

while (cursor < searchEnd)
{
    if (schedule.IsWithinBusinessHours(cursor))
    {
        if (schedule.TryBook(cursor))
        {
            bookedSlot = cursor;
            break;
        }
    }
    cursor = cursor.AddMinutes(schedule.SlotMinutes);
}

if (bookedSlot is null) throw new InvalidOperationException("no slot");

var smsGen = new SmsReminderGenerator();
Console.WriteLine(smsGen.SmsReminder(bookedSlot.Value, "0100"));

Console.WriteLine("Done. Responsibilities are split, and the runner output remains intact.");