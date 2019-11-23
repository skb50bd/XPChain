using Data.Persistence;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.Controllers
{
    [ApiController]
    public class XpController : ControllerBase
    {
        private readonly ILedgerRepository _ledger;
        public XpController(
            ILedgerRepository ledger)
        {
            _ledger = ledger;
        }

        [HttpGet("/ledger/Chain")]
        public IEnumerable<Block> GetChain()
        {
            return _ledger.GetAll();
        }

        [HttpGet("/ledger/BlockByHash/{hash}")]
        public Block GetByHash([FromRoute]string hash)
        {
            return _ledger.GetByHash(hash);
        }

        [HttpGet("/ledger/NextBlock/{currentBlockHash}")]
        public Block GetNextBlock(string currentBlockHash)
        {
            return _ledger.GetNextBlock(currentBlockHash);
        }

        [HttpGet("/ledger/LastHash")]
        public string GetLastBlockHash()
        {
            return _ledger.GetLastBlockHash();
        }

        [HttpGet("/ledger/LastBlock")]
        public Block GetLastBlock()
        {
            return _ledger.GetLastBlock();
        }

        [HttpGet("/ledger/Length")]
        public int GetChainLength()
        {
            return _ledger.GetChainLength();
        }

        [HttpGet("/ledger/Genesis")]
        public Block GetGenesisBlock()
        {
            return _ledger.GetGenesisBlock();
        }

        [HttpGet("/ledger/InsertBlock/{block}")]
        public Block InsertBlock([FromRoute]Block block)
        {
            return _ledger.Insert(block);
        }
    }
}
