/**
 *  Implementation of the class EntityTracker
 *  
 * This is a singleton that maintains a dictionary of unique id string to Trackable reference pairs. 
 * Global access and retrieval of contained Trackable instances from the dictionary is available.
 * Trackable instances are added implicitly to this class on construction and removed on destruction.
 * A Trackable object can also be removed from the internal dictionary by calling forgetEntity().
 * 
 * @author Steven E. Barbaro
 * @date November 13th, 2011
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gears.Playable;

namespace Gears.Cloud
{
    public static class EntityTracker
    {

        // A dictionary pairing unique id strings to Trackable object references.
        private static Dictionary<string, Trackable> _entities = _entities = new Dictionary<string, Trackable>();


        /**
          * @fn public static void trackEntity(Trackable entity)
          *
          * @brief Adds a <string, Trackable> pair for the passed entity to the dictionary _entities. 
          *
          * If a pair already exists this method does nothing.
          * 
          * @author Steven E. Barbaro
          *
          * @param Trackable The entity to create the pair for. 
          *
          * @see getTrackedEntity() and forgetEntity()
          */
        public static void trackEntity(Trackable entity)
        {
            // If the entity is valid and not already present in the dictionary
            if (entity != null && EntityTracker.getTrackedEntity(entity.getUUID()) == null)
            {
                // Add this entity to the dictionary
                _entities.Add(entity.getUUID(), entity);
            }
        }

        /**
         * @fn public static void forgetEntity(Trackable entity)
         *
         * @brief Removes the <string, Trackable> pair for the passed entity from the dictionary _entities.
         *
         * @author Steven E. Barbaro
         *
         * @param Trackable The entity reference to remove from the dictionary.
         *
         * @see getTrackedEntity() and trackEntity(). 
         */
        public static void forgetEntity(Trackable entity)
        {
            // If the entity is valid
            if (entity != null)
            {
                // Remove this entity from the dictionary
                _entities.Remove(entity.getUUID());
            }
        }

        /**
         * @fn public static Trackable getTrackedEntity(string id)
         *
         * @brief Returns a Trackable reference paired in the dictionary _entities with the passed id.
         *
         * If a match is not found this method returns null.
         * 
         * @author Steven E. Barbaro
         *
         * @param id The UUID string to search in the dictionary for the pair.
         *
         * @see forgetEntity() and trackEntity(). 
         */
        public static Trackable getTrackedEntity(string id)
        {
            // Default the return reference to null for fail case.
            Trackable return_object = null;

            // Retrieve an entity in the dictionary paired with the passed id. If no match is found return_object remains null.
            _entities.TryGetValue(id, out return_object);

            return return_object;
        }
    }
}
