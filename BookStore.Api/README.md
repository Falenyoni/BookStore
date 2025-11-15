### Why commad as a Record
-Response dto as a class
- This is a design choice
- commands or queries are immutable messages. So they represent a single intention like Create a Book with this data.
- By making them records we get a few cool features for free
  1. We get value based equality - so two commands with the same data are considered equal
  2. you get a super concise syntax
  3. Most importantly they are naturally immutable which is ideal for messages being passed around


#### Why a response is a class:
- Responses are typically just Dto's - data transfer objects that are sent back from our API. Developers often default to a class because
1. Historically , for example serialization libraries had better support for classes with setters
2. Responses are often mutable containers, especially when using object mapping libraries, like automapper to fill them data after construction.
3. Sometimes its just conventions


### CQRS
- CQRS is a design pattern that separates operations that change state (called commands) from the operations that read state(called queries)
- Using CQRS simplifies our code base by giving each piece a clear single responsibility.
-  It also let you optimize your read and write models independently.Which can be a huge win in more complex applications
- Since Vertical slice Architecture is about single purpose features, CQRS fits in beatifully with this architecture.