﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Extensions;

namespace TikkaIos.Data
{

    public class GameDatabase
    {
        private string DatabasePath { get; set; }
        private object DbLock = new object();

        public GameDatabase(string dbPath)
        {
            this.DatabasePath = dbPath;
            EnsureDbExists(dbPath);
        }
        
        public Game GetGameById(int id)
        {
            using (var conn = GetNewConnection())
            {
                return conn.GetWithChildren<Game>(id, true);
            }
        }
        public Game SaveGame(Game game)
        {
            lock (DbLock)
            {
                using (var conn = GetNewConnection())
                {
                    if(game.Id == Game.IdNotSavedInDb)
                    {
                        conn.InsertWithChildren(game, true);
                    }
                    else
                    {
                        conn.UpdateWithChildren(game);
                    }
                }
            }

            return GetGameById(game.Id);
        }

        public int GetNumberOfGames()
        {
            using (var conn = GetNewConnection())
            {
                return conn.Table<Game>().Count();
            }
        }

        protected SQLiteConnection GetNewConnection()
        {
            return new SQLiteConnection(DatabasePath);
        }
        protected void EnsureDbExists(string dbPath)
        {
            lock (DbLock)
            {
                // DeleteAllGames();
                using (var conn = new SQLiteConnection(dbPath))
                {
                    if (!DoesTableExist(conn, DatabaseConsts.GameTableName))
                    {
                        conn.CreateTable<Game>();
                    }
                    if (!DoesTableExist(conn, DatabaseConsts.GameScoreTableName))
                    {
                        conn.CreateTable<GameScore>();
                    }
                }
            }
        }

        protected bool DoesTableExist(SQLiteConnection conn, string tableName)
        {
            // https://stackoverflow.com/questions/1601151/how-do-i-check-in-sqlite-whether-a-table-exists
            var foundTableName = conn.ExecuteScalar<string>($"SELECT name FROM sqlite_master WHERE type='table' AND name='{tableName}'");

            return !string.IsNullOrWhiteSpace(foundTableName);
        }

        public Game GetLastGame()
        {
            using (var conn = GetNewConnection())
            {
                var result = (from g in conn.Table<Game>()
                             orderby g.StartDate
                             select g).FirstOrDefault<Game>();
                if (result != null)
                {
                    return GetGameById(result.Id);
                }
                else
                {
                    return null;
                }
            }
        }

        internal void InsertDummyDataIfNotExists()
        {
            int numGames = GetNumberOfGames();
            if (numGames <= 0)
            {
                Game game1 = new Game();
                game1.TeamAName = "team a here";
                game1.TeamBName = "team b here";
                game1.Scores.Add(new GameScore()
                {
                    ScoreIndex = 0,
                    BidTeamA = 8,
                    WonTeamA = 8,
                    BidTeamB = 0,
                    WonTeamB = 0
                });

                game1.Scores.Add(new GameScore()
                {
                    ScoreIndex = 1,
                    BidTeamA = 0,
                    WonTeamA = 0,
                    BidTeamB = 9,
                    WonTeamB = 9
                });

                game1.Scores.Add(new GameScore()
                {
                    ScoreIndex = 2,
                    BidTeamA = 10,
                    WonTeamA = -20,
                    BidTeamB = 0,
                    WonTeamB = 0
                });

                game1.Scores.Add(new GameScore()
                {
                    ScoreIndex = 3,
                    BidTeamA = 0,
                    WonTeamA = 0,
                    BidTeamB = 13,
                    WonTeamB = 26
                });

                SaveGame(game1);


                var savedGame = GetGameById(game1.Id);
            }
        }
        internal void DeleteAllGames()
        {
            using (var conn = GetNewConnection())
            {
                conn.DropTable<GameScore>();
                conn.DropTable<Game>();
            }
        }
    }

    public class GameSummary
    {
        public int GameId { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
    }



}