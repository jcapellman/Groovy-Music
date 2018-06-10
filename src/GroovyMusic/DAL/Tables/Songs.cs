﻿using System;

using SQLite;

namespace GroovyMusic.DAL.Tables
{
    public class Songs
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [Indexed]
        public string Name { get; set; }

        [Indexed]
        public string Artist { get; set; }

        public int TrackNumber { get; set; }

        public TimeSpan Duration { get; set; }
    }
}