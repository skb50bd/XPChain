using Domain;
using System;
using System.Collections.Generic;
using LiteDB;

namespace Data.Persistence
{
    public interface ILedgerRepository : IDisposable
    {
        string GetLastBlockHash();

        Block GetLastBlock();

        int GetChainLength();

        Block GetGenesisBlock();

        Block GetNextBlock(string currentBlockHash);

        Block Insert(Block item);

        IEnumerable<Block> GetAll();

        Block GetById(ObjectId id);
        Block GetByHash(string hash);

        IEnumerable<T> GetAll<T>();
        T GetById<T>(ObjectId id);
    }
}
