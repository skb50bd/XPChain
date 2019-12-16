using Domain;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Persistence
{
    public interface ILedgerRepository : IDisposable
    {
        string GetLastBlockHash();

        Block GetLastBlock();

        int GetChainLength();

        Block GetGenesisBlock();

        Block GetNextBlock(string currentBlockHash);

        Task<Block> Insert(Block item);

        IEnumerable<Block> GetAll();

        Block GetById(string id);
        Block GetByHash(string hash);

        IEnumerable<T> GetAll<T>();
        T GetById<T>(string id);
    }
}
