namespace CyanDevelopers.GMCX12.Core.Updaters;

// TODO implement double buffer
// the drawing can be in double buffer - first it will determine rules and drawing lambda and then it will do it
public abstract class Updater {
	public bool Enabled = true;
	public virtual void Update(float dt) {
		foreach (Updater child in Children)
			if (child.Enabled) child.Update(dt);
	}
	public virtual void Draw(float dt) {
		foreach (Updater child in Children)
			if (child.Enabled) child.Draw(dt);
	}
	public IEnumerable<Updater> Children = [];
}
