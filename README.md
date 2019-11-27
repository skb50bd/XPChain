# XPChain

## Introduction

**XPChain** is a Blockchain-based distributed experience point recording platform. Here organizations and working people participate. XPChain keeps track of an employee's workplace performance and achievements in an immutable and permanent manner. This helps the recruiters to make right selection and the employees to get a job of their potential.

## Components

XPChain implementation has the following components.

- **XPHub** [yet to be implemented] - When an organization wants to join the XPChain system, they register in _XPHub_. It also provides the recruitment facilities. Member organizations can post new job requirements and potential employees can look those up and respond here. On the other hand, the employees can post if they are seeking jobs, and the organizations can search through the interested employees and send offer letters.
- **XPChain** - Organizations are the record keepers of the XPChain database. They participate in the P2P network that makes up the XPChain network. All organizations in the network must setup a blockchain node. They maintain a **local** database that holds all records to their organization. When any data is properly created and validated by the organization and the corresponding employee, it can be published to the Blockchain network. The distributed Blockchain database is immutable, permanent and is reflected between all nodes in the system.
- **CryptoApp** - It is a standalone tool that provides some functionalities. It can generate public-private key-pairs that can be used with XPChain system. It can also generate digital signatures and check validity of those digital signatures.

## Getting Started

You need `.Net 3.0 SDK` to build the project.
`cd` into the `/src/Core/` folder and enter `dotnet run` to build and run the **XPChain** Project.
**CryptoApp** can be run in the similar manner. Just `cd` into `/src/CryptoApp/` and enter `dotnet run`. The Windows Forms application will build and run.

## Contact

To learn more, feel free to contact:

1. Abdullah - Al - Haris Shakib - skb50bd@gmail.com
2. Ashiful Arefin - arefin.ashiful@gmail.com
3. Shaila Sarker - shaila.sarker@gmail.com
