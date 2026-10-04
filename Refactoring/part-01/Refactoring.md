# Part 01 - Refactoring Lab Answers

## Task 1.1 - Shipping, Orders & Notifications

### R1 & R5: Shipping Cost Calculator (Open/Closed Principle - Strategy Pattern)
- **Problem:** The original `ShippingCostCalculator` relied on hard-coded branching/conditionals to calculate shipping costs based on the carrier name[cite: 1, 2]. Adding a new carrier required modifying existing methods[cite: 2].
- **Refactoring Applied:** Applied the **Strategy Pattern** by introducing an `ICarrier` interface[cite: 2]. Each carrier (`FedExCarrier`, `DHLCarrier`, `AramexCarrier`) implements its own calculation logic[cite: 2].
- **Adding a new carrier:** Added `AramexCarrier` by creating a new class without modifying any existing class or logic[cite: 2].


### R2: Order Processor (Dependency Inversion Principle)
- **Problem:** `OrderProcessor` directly instantiated its dependencies (`SqlOrderRepository` and `SmtpEmailSender`) internally, creating tight coupling[cite: 1, 2].
- **Refactoring Applied:** Injected abstractions (`IOrderRepository` and `IEmailSender`) into `OrderProcessor` using constructor injection[cite: 2].


### R3 & R6: Notifications (Composition over Inheritance - Decorator Pattern)
- **Problem:** Extending notifications via class inheritance led to an exploding inheritance tree (e.g., `UrgentEmailNotification`, `ScheduledSmsNotification`, etc.)[cite: 1, 2].
- **Refactoring Applied:** Used **Composition (Decorator Pattern)** over inheritance[cite: 1, 2]. Created base channel implementations (`EmailNotificationSender`, `SmsNotificationSender`, `WhatsAppNotificationSender`) and wrapped them with behavior decorators (`UrgentNotificationSender`, `ScheduledNotificationSender`)[cite: 2].
- **Flexibility:** Channels and behaviors can be combined dynamically (e.g., Urgent + Scheduled + Email) without class explosion[cite: 2].