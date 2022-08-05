# Voodoo test

### Explanetion of architecture:

#### I used:
 - MVC pattern for Units and Game entities. It's simple for use and give less coherency between data and logic. Easier to add save and load options.
 - FSM pattern for units behavior. This allow to separate logic for different states of entity, easy control transition between states and give more opportunities for adding new behavior.
 - GameRoot is a single enter point.
 - Descriptions as assets for holding settings data. Easy to add new config and store old for reuse late. Can be added by pressing RMB in project window -> Create -> Descriptions -> choose type you need![Screenshot_19](https://user-images.githubusercontent.com/55126522/183149183-e0387dd7-b5d1-44f6-9023-9fc954ce1217.png)

 - Library as a storage for all descriptions and opportunity to get what you need by ID. Just press Button and it will find all descriptions in the assets and add to list.
 ![Screenshot_17](https://user-images.githubusercontent.com/55126522/183148565-7ecfeed9-8dee-417a-8daf-a378a1d40684.png)
 - Identifiers as assets for chaining Descriptions or all other entities with less coherency. It's easy to add and manage![Screenshot_20](https://user-images.githubusercontent.com/55126522/183149398-1785e9a6-1634-4583-821c-4b95a6b3b845.png)

 - ServiceLocator for Update and tartgeting. It helps easier solve dependancy problems for entities.

#### Additional feature:
I don't have time to realize, but I would like to add rogue-like choice. Like in Archero add one more ability to use for your army. 


