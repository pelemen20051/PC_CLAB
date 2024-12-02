namespace Practic
{
    partial class CatalogForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewProducts = new System.Windows.Forms.TreeView();
            this.buttonAddToCart = new System.Windows.Forms.Button();
            this.buttonViewCart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewProducts
            // 
            this.treeViewProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.treeViewProducts.Location = new System.Drawing.Point(34, 12);
            this.treeViewProducts.Name = "treeViewProducts";
            this.treeViewProducts.Size = new System.Drawing.Size(657, 342);
            this.treeViewProducts.TabIndex = 1;
            // 
            // buttonAddToCart
            // 
            this.buttonAddToCart.Location = new System.Drawing.Point(34, 405);
            this.buttonAddToCart.Name = "buttonAddToCart";
            this.buttonAddToCart.Size = new System.Drawing.Size(75, 23);
            this.buttonAddToCart.TabIndex = 2;
            this.buttonAddToCart.Text = "ДОБАВИТЬ";
            this.buttonAddToCart.UseVisualStyleBackColor = true;
            this.buttonAddToCart.Click += new System.EventHandler(this.buttonAddToCart_Click);
            // 
            // buttonViewCart
            // 
            this.buttonViewCart.Location = new System.Drawing.Point(137, 404);
            this.buttonViewCart.Name = "buttonViewCart";
            this.buttonViewCart.Size = new System.Drawing.Size(75, 23);
            this.buttonViewCart.TabIndex = 3;
            this.buttonViewCart.Text = "корзина";
            this.buttonViewCart.UseVisualStyleBackColor = true;
            this.buttonViewCart.Click += new System.EventHandler(this.buttonViewCart_Click);
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonViewCart);
            this.Controls.Add(this.buttonAddToCart);
            this.Controls.Add(this.treeViewProducts);
            this.Name = "CatalogForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewProducts;
        private System.Windows.Forms.Button buttonAddToCart;
        private System.Windows.Forms.Button buttonViewCart;
    }
}

