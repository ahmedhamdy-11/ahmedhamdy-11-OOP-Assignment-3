
# Part 03 - Blocked Users & Students Answers

## Task 1.4 - Performance & Lazy Evaluation

### Blocked Users Optimization (HashSet Lookup)
- **Before Refactoring:**
  - **Time Complexity:** $\mathcal{O}(N \times M)$ where $N$ is the number of request IDs and $M$ is the number of blocked IDs[cite: 3, 7].
  - **Execution Time:** ~ `[سجل الوقت بالـ ms هنا لما شغلته بـ List]` ms[cite: 3].
- **After Refactoring:**
  - **Time Complexity:** $\mathcal{O}(N + M)$ using `HashSet<int>`[cite: 3, 7].
  - **Execution Time:** ~ `[سجل الوقت الجديد بالـ ms هنا]` ms[cite: 3].
  - **Found Count:** Matches original found count exactly[cite: 3].

### Student Catalog (Lazy Evaluation with `yield return`)
- **Refactoring Applied:** Changed `GetAllStudents()` to return `IEnumerable<Student>` using C# `yield return` for deferred execution (Lazy Evaluation)[cite: 3, 7].
- **Result:** When iterating and stopping after 3 items (e.g., using `break` or `.Take(3)`), only 3 student objects are instantiated on demand, avoiding memory allocation for the remaining 999,997 students[cite: 3].