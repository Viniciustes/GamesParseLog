using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Enums;
using GamesParseLog.Domain.Interfaces.Repositories;
using System;
using System.IO;

namespace GamesParseLog.Service.Services.ServicesFiles
{
    internal class ServiceFileRead
    {
        private readonly IRepositoryKill _repositoryKill;
        private readonly IRepositoryGame _repositoryGame;
        private readonly IRepositoryPlayer _repositoryPlayer;

        public ServiceFileRead(IRepositoryGame repositoryGame, IRepositoryKill repositoryKill, IRepositoryPlayer repositoryPlayer)
        {
            _repositoryGame = repositoryGame;
            _repositoryKill = repositoryKill;
            _repositoryPlayer = repositoryPlayer;

        }

        public object[] FileRead(string fileUrl)
        {
            using (StreamReader sr = File.OpenText(fileUrl))
            {
                string line = string.Empty;
                var count = 1;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains("InitGame:"))
                    {
                        var newGame = new Game
                        {
                            NameGame = "Game " + count
                        };

                        var namePlayer = string.Empty;
                        var newPlayer = new Player();
                        var newKill = new Kill();

                        var linePlayer = string.Empty;
                        while (!(linePlayer = sr.ReadLine()).Contains("------------------------------------------------------------"))
                        {
                            if (linePlayer.Contains("ClientUserinfoChanged"))
                            {
                                string[] players = linePlayer.Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries);
                                namePlayer = players[1].ToString();

                                var player = _repositoryPlayer.GetByName(namePlayer);

                                if (player == null)
                                    _repositoryPlayer.SavePlayer(new Player { NamePlayer = namePlayer });
                                else
                                    newGame.Player.Add(player);
                            }

                            if (linePlayer.Contains("Kill:"))
                            {
                                var qtdTotal = linePlayer.Length;
                                var qtdInitial = linePlayer.LastIndexOf(" by ") + 4;
                                var typeDeath = (linePlayer.Substring(qtdInitial, qtdTotal - qtdInitial)).ToString();

                                newKill.Game = _repositoryGame.GetByName("Game " + (count - 1));
                                newKill.Player = _repositoryPlayer.GetByName(namePlayer);
                                newKill.TypeOfDeath = (EMeansOfDeath)Enum.Parse(typeof(EMeansOfDeath), typeDeath);
                                _repositoryKill.SaveKill(newKill);
                            }
                        }
                        _repositoryGame.SaveGame(newGame);
                        count++;
                    }
                }
            }
            return null;
        }
    }
}