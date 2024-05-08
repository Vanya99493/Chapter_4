using _7_PlayMarketSample.Scripts.UIModule.Panels.ItemsContainerPanelModule;

namespace _7_PlayMarketSample.Scripts.Infrastructure.Services
{
    public class PrefabsProvider
    {
        public static PrefabsProvider Instance { get; } = new ();

        public ItemContainer ItemContainerPrefab;
        public ItemShortcut ItemShortcutPrefab;
        public ItemPanel ItemPanelPrefab;
    }
}