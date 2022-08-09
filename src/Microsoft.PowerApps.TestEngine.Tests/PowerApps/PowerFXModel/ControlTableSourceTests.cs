﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

using Microsoft.PowerApps.TestEngine.PowerApps;
using Microsoft.PowerApps.TestEngine.PowerApps.PowerFxModel;
using Microsoft.PowerFx.Types;
using Moq;
using System;
using Xunit;

namespace Microsoft.PowerApps.TestEngine.Tests.PowerApps.PowerFXModel
{
    public class ControlTableSourceTests
    {
        [Fact]
        public void TableSourceTest()
        {
            Mock<Microsoft.Extensions.Logging.ILogger> MockLogger = new Mock<Microsoft.Extensions.Logging.ILogger>(MockBehavior.Loose);
            var mockPowerAppFunctions = new Mock<IPowerAppFunctions>(MockBehavior.Strict);
            var itemPath = new ItemPath()
            {
                ControlName = "Gallery1",
                PropertyName = "AllItems"
            };

            var itemCount = 3;
            mockPowerAppFunctions.Setup(x => x.GetItemCount(It.IsAny<ItemPath>(), MockLogger.Object)).Returns(itemCount);
            var recordType = new RecordType().Add("Label1", new RecordType().Add("Text", FormulaType.String));
            var controlTableSource = new ControlTableSource(mockPowerAppFunctions.Object, itemPath, recordType, MockLogger.Object);
            Assert.Equal(itemCount, controlTableSource.Count);

            for(var i = 0; i < itemCount; i++)
            {
                var row = controlTableSource[i];
                Assert.Equal(i, row.ItemPath.Index);
                Assert.Equal(itemPath.ControlName, row.ItemPath.ControlName);
                Assert.Equal(itemPath.PropertyName, row.ItemPath.PropertyName);
            }
        }
    }
}
