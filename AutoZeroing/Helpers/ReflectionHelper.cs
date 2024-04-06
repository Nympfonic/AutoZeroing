using EFT.InventoryLogic;
using HarmonyLib;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace Arys.AutoZeroing.Helpers
{
    internal static class ReflectionHelper
    {
        #region WeaponTemplate Reflections

        internal static AmmoTemplate GetDefAmmoTemplate(this WeaponTemplate weaponTemplate)
        {
            return _defAmmoTemplateField.GetValue(weaponTemplate) as AmmoTemplate;
        }

        internal static void SetDefAmmoTemplate(this WeaponTemplate weaponTemplate, AmmoTemplate newTemplate)
        {
            _defAmmoTemplateField.SetValue(weaponTemplate, newTemplate);
        }

        private static readonly FieldInfo _defAmmoTemplateField = AccessTools.GetDeclaredFields(typeof(WeaponTemplate)).Single(IsDefAmmoTemplateField);

        private static bool IsDefAmmoTemplateField(FieldInfo field)
        {
            return field.FieldType == typeof(AmmoTemplate)
                && field.IsPrivate;
        }

        #endregion

        #region ItemFactory Reflections

        internal static IDictionary GetItemTemplates(this ItemFactory itemFactory)
        {
            return _itemTemplatesField.GetValue(itemFactory) as IDictionary;
        }

        private static readonly FieldInfo _itemTemplatesField = AccessTools.GetDeclaredFields(typeof(ItemFactory)).Single(IsItemTemplatesField);

        private static bool IsItemTemplatesField(FieldInfo field)
        {
            return field.Name == "ItemTemplates"
                && field.IsPublic
                && field.IsInitOnly;
        }

        #endregion
    }
}
