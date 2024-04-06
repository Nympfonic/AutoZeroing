using Arys.AutoZeroing.Helpers;
using Comfort.Common;
using EFT;
using EFT.InventoryLogic;
using UnityEngine;

namespace Arys.AutoZeroing
{
    public class AutoZeroingController : MonoBehaviour
    {
        private Player player;

        private void Start()
        {
            player = GetComponent<Player>();
        }

        private void Update()
        {
            if (IsPlayerHoldingGun(out var weapon) && HasALoadedChamber(weapon, out var chamberedAmmoTemplate))
            {
                ChangeZeroedAmmo(weapon, chamberedAmmoTemplate);
            }
        }

        private void OnDestroy()
        {
#if DEBUG
            LoggingHelper.LogInfo($"Destroying AutoZeroingController");
#endif
        }

        private bool IsPlayerHoldingGun(out Weapon weapon)
        {
            if (player.HandsController is Player.FirearmController)
            {
                weapon = (player.HandsController as Player.FirearmController).Weapon;
                return true;
            }

            weapon = null;
            return false;
        }

        private bool HasALoadedChamber(Weapon weapon, out AmmoTemplate ammoTemplate)
        {
            if (weapon.FirstLoadedChamberSlot?.ContainedItem.Template is AmmoTemplate)
            {
                ammoTemplate = weapon.FirstLoadedChamberSlot.ContainedItem.Template as AmmoTemplate;
                return true;
            }

            ammoTemplate = null;
            return false;
        }

        private void ChangeZeroedAmmo(Weapon weapon, AmmoTemplate chamberedAmmoTemplate)
        {
            if (weapon.Template.DefAmmoTemplate._id != chamberedAmmoTemplate._id)
            {
                var itemTemplates = Singleton<ItemFactory>.Instance.GetItemTemplates();
                var newDefAmmo = itemTemplates[chamberedAmmoTemplate._id] as AmmoTemplate;

#if DEBUG
                LoggingHelper.LogInfo($"Changing player's current weapon to be zeroed to {newDefAmmo._name}");
#endif

                weapon.Template.SetDefAmmoTemplate(newDefAmmo);
            }
        }
    }
}
