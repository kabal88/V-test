# Voodoo test

### Explanetion of architecture:

I used:
 - MVC pattern for Units and Game entities. It's simple for use and give less coherency between data and logic.
 - FSM pattern for units behavior. This allow to separate logic for different states of entity, easy control transition between states and give more opportunities for adding new behavior.
 - GameRoot is a single enter point.
 - Descriptions as assets for holding settings data. Easy to add new config and store old for reuse late.
 - Identifiers as assets for chaining Descriptions or all other entities with less coherency.
 - ServiceLocator for Update and tartgeting. It helps easier solve dependancy problems for entities.

 Additional feature:
    I don't have time to realize, but I would like to add rogue-like choice. Like in Archero add one more ability to use for your army. 


