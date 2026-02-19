namespace CyanDevelopers.GMCX12.Core.Updaters;

public class ServiceUpdater : Updater {

	public ServiceUpdater(params IEnumerable<Service> children)
	{
		Children = children;
		ServiceHandler handler = new(Children);
		foreach (Service child in children) child.ServiceHandler = handler;
	}

	public new IEnumerable<Service> Children;
}

public abstract class Service : Updater {
	public ServiceHandler ServiceHandler { private get; set; } = new();
}

public class ServiceHandler(params IEnumerable<Service> services) {
	public T GetUpdater<T>() where T : Updater {
		foreach (Updater service in services) if (service is T correct) return correct;
		throw new NullReferenceException();
	}
}
