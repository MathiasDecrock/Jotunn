﻿using System.Collections.Generic;
using Jotunn.Configs;
using Jotunn.Managers;
using UnityEngine;

namespace Jotunn.Entities
{

    /// <summary>
    ///     Main interface for adding custom locations to the game.<br />
    ///     All custom locations have to be wrapped inside this class to add it to Jötunns <see cref="ZoneManager"/>.
    /// </summary>
    public class CustomLocation : CustomEntity
    {
        /// <summary>
        ///     The exterior prefab for this custom location.
        /// </summary>
        public GameObject Prefab { get; }
        /// <summary>
        ///     Associated <see cref="ZoneSystem.ZoneLocation"/> component
        /// </summary>
        public ZoneSystem.ZoneLocation ZoneLocation { get; }
        /// <summary>
        ///     Associated <see cref="Location"/> component
        /// </summary>
        public Location Location { get; }
        /// <summary>
        ///     Name of this custom location
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Custom location from a prefab with a <see cref="LocationConfig"/> attached.<br />
        /// </summary>
        /// <param name="exteriorPrefab">The exterior prefab for this custom location.</param>
        /// <param name="locationConfig">The <see cref="LocationConfig"/> for this custom location.</param>
        public CustomLocation(GameObject exteriorPrefab, LocationConfig locationConfig) : this(exteriorPrefab, null, locationConfig) { }

        /// <summary>
        ///     Custom location from a prefab with a <see cref="LocationConfig"/> attached.<br />
        /// </summary>
        /// <param name="exteriorPrefab">The exterior prefab for this custom location.</param>
        /// <param name="interiorPrefab">The interior prefab for this custom location.</param>
        /// <param name="locationConfig">The <see cref="LocationConfig"/> for this custom location.</param>
        public CustomLocation(GameObject exteriorPrefab, GameObject interiorPrefab, LocationConfig locationConfig)
        {
            Prefab = exteriorPrefab;
            Name = exteriorPrefab.name;
            
            if (exteriorPrefab.TryGetComponent<Location>(out var location))
            {
                Location = location;
            }
            else
            {
                Location = exteriorPrefab.AddComponent<Location>();
                Location.m_hasInterior = locationConfig.InteriorRadius > 0f;
                Location.m_exteriorRadius = locationConfig.ExteriorRadius;
                Location.m_clearArea = locationConfig.ClearArea;
                Location.m_interiorPrefab = interiorPrefab;
            }

            ZoneLocation = locationConfig.GetZoneLocation();
            ZoneLocation.m_prefab = exteriorPrefab;
            ZoneLocation.m_prefabName = exteriorPrefab.name;
            ZoneLocation.m_hash = exteriorPrefab.name.GetStableHashCode();
            ZoneLocation.m_location = Location;
        }
    }
}
