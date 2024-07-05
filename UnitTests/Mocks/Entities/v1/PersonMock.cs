using Domain.Entities.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Mocks.Entities.v1;

public static class PersonMock
{
    public static Person GetSuccessMock() =>
        new()
        {
            Name = "Guilherme",
            Document = "444.444.555-66",
            Email = "guilherme@email.com",
            Birthday = new DateTime(1993, 10, 6),
            Phone = "1633332222",
            Address = new Domain.ValueObjects.v1.Address("14802-020", "Avenida Joaquim", "20", "Bairro", "Araraquara", "SP")
        };
}
