﻿using Boa.Constrictor.Screenplay;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Boa.Constrictor.WebDriver
{
    /// <summary>
    /// Right clicks a Web element.
    /// </summary>
    public class RightClick : AbstractWebLocatorTask
    {
        #region Constructors

        /// <summary>
        /// Private constructor.
        /// (Use static builder methods to construct.)
        /// </summary>
        /// <param name="locator">The target Web element's locator.</param>
        private RightClick(IWebLocator locator) : base(locator) { }

        #endregion
        
        #region Builder Methods

        /// <summary>
        /// Constructs the task object.
        /// </summary>
        /// <param name="locator">The target Web element's locator.</param>
        /// <returns></returns>
        public static RightClick On(IWebLocator locator) => new RightClick(locator);

        #endregion

        #region Methods

        /// <summary>
        /// Right Clicks the web element.
        /// Use browser actions instead of direct click (due to IE).
        /// </summary>
        /// <param name="actor">The screenplay actor.</param>
        /// <param name="driver">The WebDriver.</param>
        public override void PerformAs(IActor actor, IWebDriver driver)
        {
            actor.WaitsUntil(Appearance.Of(Locator), IsEqualTo.True());
            new Actions(driver).MoveToElement(driver.FindElement(Locator.Query)).ContextClick().Perform();
        }

        #endregion
    }
}
