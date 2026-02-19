# GMCX12

## Updaters
- Based on `foreach List<IUpdatable> obj.update()` and `foreach List<IDrawable> obj.draw()` **without the** `List` **part**.
- "Scripted" objects that run update and draw methods of the objects.
- To make it complex, it is nested - there is array of children updaters. (they are updated by the Updater base)
