
``` mermaid
stateDiagram-v2
    [*] --> Detached: new T
    [*] --> Unchanged: First(), ToList()

    Detached --> Unchanged: Attach
    Detached --> Added: Add

    Unchanged --> Modified: SetProperty
    Modified --> Unchanged: SaveChanges

    Unchanged --> Deleted: Remove
    Modified --> Deleted: Remove

    Deleted --> Detached: SaveChanges

    Added --> Unchanged: SaveChanges
    Added --> Detached: Remove

    Unchanged --> Detached: SaveChanges (no tracking)
```

| Stan      | Opis |
|-----------|------|
| Detached  | Encja nie jest śledzona przez DbContext. Nie ma powiązania z kontekstem. |
| Added     | Encja została dodana i nie istnieje jeszcze w bazie. Po SaveChanges staje się Unchanged. |
| Unchanged | Encja jest w bazie i śledzona, ale nie zmieniona. |
| Modified  | Encja jest w bazie i śledzona, ale zmieniono jej właściwości. Po SaveChanges staje się Unchanged. |
| Deleted   | Encja istnieje w bazie, jest śledzona i oznaczona do usunięcia. Po SaveChanges staje się Detached. |
