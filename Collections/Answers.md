# Part 02 - Collections & Research Answers

## Task 2.1 - Research: IReadOnlyDictionary & SortedDictionary

### 1. IReadOnlyDictionary<TKey, TValue>
- **What it is:** A interface that provides a read-only view of a key-value collection without exposing methods to modify the contents.
- **Difference from Dictionary:** Unlike `Dictionary<TKey, TValue>`, it lacks modification methods like `Add()`, `Remove()`, `Clear()`, or a public indexer setter (`this[key] = value`).
- **Why return it from a public method:** To practice **Encapsulation**. Returning `IReadOnlyDictionary` guarantees that callers cannot tamper with or mutate internal state/data structure returned by the method.

### 2. SortedDictionary<TKey, TValue>
- **Difference from Dictionary in Ordering:** `Dictionary` uses a hash table and does not preserve or guarantee key order. `SortedDictionary` uses a balanced binary search tree (Red-Black Tree) and keeps elements automatically sorted by Key.
- **Difference in Lookup Speed:** 
  - `Dictionary` has $\mathcal{O}(1)$ average lookup time.
  - `SortedDictionary` has $\mathcal{O}(\log N)$ lookup time due to tree traversal.
- **When to choose SortedDictionary:** Choose it when keeping items sorted by key at all times is mandatory (e.g., printed timetables, chronological logs) and you iterate through keys sequentially.

---

## Task 2.2 - Pick the Collection

| Scenario | Collection Chosen | Reason |
|---|---|---|
| **S1** | `Dictionary<string, Student>` | Fast $\mathcal{O}(1)$ key lookup by National ID across high query volumes. |
| **S2** | `HashSet<string>` | Ensures all course tags are strictly unique and prevents duplicates efficiently. |
| **S3** | `List<int>` | Preserves insertion order of grades and allows duplicate values. |
| **S4** | `IReadOnlyDictionary<string, decimal>` | Exposes prices to external consumers safely while preventing modification. |
| **S5** | `SortedDictionary<DateTime, Session>` | Automatically maintains timetable order chronologically by session start time. |
| **S6** | `IEnumerable<T>` | Supports deferred/lazy execution, enabling callers to stop early without loading all records. |