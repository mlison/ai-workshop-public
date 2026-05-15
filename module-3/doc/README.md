# DispatchKit Documentation

System-of-record documentation. What DispatchKit is, how it's built, how to operate it.

Distinct from `../AGENTS.md`, which captures *how we work*. This directory captures *what the system does*. See the maintenance rule in AGENTS.md if you're not sure where something belongs.

## Directories

- `domain/` — domain model: entities, terminology, business rules.
- `architecture/` — architecture decisions, command patterns, integration shapes.
- `runbooks/` — operational procedures and incident response.

## Decision heuristic

Would the doc transfer cleanly to a new system? Then it's a working pattern — belongs in AGENTS.md. Is it about *this specific system's* shape or state? Then it belongs here.
