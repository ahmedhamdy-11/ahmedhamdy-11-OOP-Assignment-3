
# Part 02 - Reports & Enrollment Answers

## Task 1.2 - Reports (Template Method Pattern)

### R4: Why is an abstract class a better fit than an interface in this case?
An **abstract class** is the best fit here because the Template Method pattern relies on enforcing a fixed, reusable execution workflow (`Export` algorithm: `Load` → `Validate` → `Format` → `Save`) and sharing common helper logic (file saving) across all implementations[cite: 3]. 

An `interface` only defines a contract of methods without sharing behavior or enforcing an execution sequence, which would force us to duplicate file-writing and validation logic inside every exporter class[cite: 3].

---

## Task 1.3 - Enrollment (Facade Pattern)

### R4: What problem does the Facade solve here, and what does the caller no longer need to know?
- **Problem Solved:** The **Facade Pattern** hides the internal complexity of a multi-step workflow behind a single, unified interface[cite: 1, 3]. It decouples the caller (`Program.cs`) from the internal service dependencies (`PaymentGateway`, `SeatInventory`, `InvoiceGenerator`, `EmailService`)[cite: 3].
- **What the caller no longer needs to know:**
  1. The caller no longer needs to instantiate or manage the lifecycles of individual subsystem service classes[cite: 3].
  2. The caller does not need to know the specific sequence of execution or parameter dependencies between services required to complete an enrollment[cite: 3].
  3. Any internal changes to the enrollment process can be updated inside `EnrollmentFacade` without breaking caller code[cite: 1, 3].