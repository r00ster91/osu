﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Framework.Logging;
using osu.Framework.Platform;

namespace osu.Game.Database
{
    public abstract class DatabaseBackedStore
    {
        protected readonly Storage Storage;

        protected readonly Func<OsuDbContext> GetContext;

        protected DatabaseBackedStore(Func<OsuDbContext> getContext, Storage storage = null)
        {
            Storage = storage;
            GetContext = getContext;

            try
            {
                Prepare();
            }
            catch (Exception e)
            {
                Logger.Error(e, $@"Failed to initialise the {GetType()}! Trying again with a clean database...");
                Prepare(true);
            }

            StartupTasks();
        }

        /// <summary>
        /// Perform any common startup tasks. Runs after <see cref="Prepare(bool)"/> and <see cref="PerformMigration(int, int)"/>.
        /// </summary>
        protected virtual void StartupTasks()
        {
        }

        /// <summary>
        /// Prepare this database for use. Tables should be created here.
        /// </summary>
        protected abstract void Prepare(bool reset = false);

        /// <summary>
        /// Reset this database to a default state. Undo all changes to database and storage backings.
        /// </summary>
        public void Reset() => Prepare(true);
    }
}
