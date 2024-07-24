using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Mindustry
{
    public static class Utils
    {
        public static bool IsPointerOverUIElement()
        {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
            {
                position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
            };

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
            return results.Count > 0;
        }
    }
}
