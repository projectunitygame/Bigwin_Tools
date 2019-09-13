<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="CMS_Tools.Test" %>
<table id="user" class="table table-bordered table-striped" style="display:none;">
                                        <tbody>
                                            <tr>
                                                <td colspan="10" class="header1">THÔNG TIN KHÁCH HÀNG</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 10%">Ngày Mở</td>
                                                <td style="width: 10%">Ngày Giao</td>
                                                <td style="width: 10%">Mã DC</td>
                                                <td style="width: 10%">Ký Hiệu</td>
                                                <td style="width: 10%">Mã KH</td>
                                                <td style="width: 10%">Liên Hệ</td>
                                                <td style="width: 20%" colspan="2">Loại Đơn</td>
                                                <td style="width: 20%" colspan="2">Loại Hình SX</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <label id="">14/03/2019</label></td>
                                                <td>
                                                    <label id="">19/03/2019</label></td>
                                                <td>
                                                    <label id="">1903D0001</label></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Mã KH" />
                                                </td>
                                                <td>
                                                    <label id="">A Lộc</label></td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">Sản Xuất</option>
                                                        <option value="2">Thương Mại</option>
                                                        <option value="3">Sản Xuất & Thương Mại</option>
                                                    </select>
                                                </td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">Điện Tử</option>
                                                        <option value="2">May Mặc</option>
                                                        <option value="3">Nội Thất</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <label id="">CTY TNHH DV TÚ PHÚ</label></td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option>Khu Vực</option>
                                                        <option value="Category 1">Hồ Chí Minh</option>
                                                        <option value="Category 2">Bình Dương</option>
                                                        <option value="Category 3">Cần Thơ</option>
                                                    </select>
                                                </td>
                                                <td>
                                                    <label id="">Số KM</label></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Số KM" readonly /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="10" class="header1">THÔNG TIN ĐƠN HÀNG</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Ký Hiệu</td>
                                                <td colspan="2">Số Đơn KH</td>
                                                <td colspan="2">Tên Sản Phẩm</td>
                                                <td colspan="2">Số PO</td>
                                                <td colspan="2">Nhà Cung Cấp</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">A1-1T</option>
                                                        <option value="2">A2-2T</option>
                                                        <option value="3">A3-3T</option>
                                                    </select>
                                                </td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" />
                                                </td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" />
                                                </td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" />
                                                </td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">Chọn nhà cung cấp</option>
                                                        <option value="1">Điện Tử</option>
                                                        <option value="2">May Mặc</option>
                                                        <option value="3">Nội Thất</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <label id="">Quy Cách Khách Hàng</label></td>
                                                <td colspan="3">
                                                    <label id="">Quy Cách Sản Xuất</label></td>
                                                <td>
                                                    <label id="">Lưỡi Gà</label></td>
                                                <td colspan="3">
                                                    <label id="">Số Lượng</label></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Dài" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Rộng" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Cao" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Dài" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Rộng" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Cao" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control"/>
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="SL" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="SL Tặng" />
                                                </td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" readonly />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Cắt Dài,Rộng Thùng</td>
                                                <td colspan="2">Quy Cách Đặt Mua(Khổ Giấy)</td>
                                                <td>SL Sản Xuất</td>
                                                <td>SL Bị Liệu</td>
                                                <td>Cái/Tấm</td>
                                                <td colspan="2">Chất Liệu</td>
                                                <td>Đóng/Dán Kim</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input type="text" class="form-control" readonly placeholder="D" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" readonly placeholder="R" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" readonly placeholder="D" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" readonly placeholder="R" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" readonly placeholder="SLSX" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" paceholder="SLBL" />
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" readonly placeholder="Cái" />
                                                </td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">ZXZ(C)</option>
                                                        <option value="2">ZGZ(C)</option>
                                                        <option value="3">Z+Z(E)</option>
                                                    </select>
                                                </td>
                                                <td>
                                                    <select class="form-control">
                                                        <option value="1">Đóng đinh đơn</option>
                                                        <option value="2">Đóng đinh đôi</option>
                                                        <option value="3">Dán</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Số Màu IN</td>
                                                <td>In Ấn</td>
                                                <td>Cán Biên</td>
                                                <td>Máy In</td>
                                                <td>Cắt Rãnh</td>
                                                <td>Máy Bế</td>
                                                <td>Đóng Đinh</td>
                                                <td>Dán Keo</td>
                                                <td colspan="2">Đóng Gói</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="Màu IN" />
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td class="center">
                                                    <label class="mt-checkbox">
                                                        <input type="checkbox" value="1" name="service" />
                                                        <span></span>
                                                    </label>
                                                </td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">Cột 2 đầu</option>
                                                        <option value="2">Cột 1 đầu</option>
                                                        <option value="2">Lót giấy 2 bên</option>
                                                        <option value="2">Gói bao giấy</option>
                                                        <option value="2">Gói nylon</option>
                                                        <option value="2">Đóng thùng</option>
                                                    </select>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Gia Công ĐB</td>
                                                <td colspan="9">
                                                    <input type="text" class="form-control" placeholder="Ghi chú" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Cán Nắp(rộng)</td>
                                                <td colspan="3">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td colspan="2">Cán Lằn In(dài)</td>
                                                <td colspan="3">
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                            <td>
                                                                <input type="text" class="form-control" readonly /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Loại Bản IN</td>
                                                <td>Mã Số Bản IN</td>
                                                <td>Mã Số Khuôn Bế</td>
                                                <td colspan="2">Kèm Theo</td>
                                                <td>DT/Cái(m2)</td>
                                                <td>Tổng DT(m2)</td>
                                                <td>Số Mét Tới</td>
                                                <td>SL Tối Thiểu</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">Bản mới</option>
                                                        <option value="2">Bản cũ</option>
                                                        <option value="2">Sửa bản cũ</option>
                                                    </select>
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td colspan="2">
                                                    <select class="form-control">
                                                        <option value="1">Theo mẫu</option>
                                                        <option value="2">Bản vẽ</option>
                                                    </select>
                                                </td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="10" class="header1">GIÁ - CHI PHI - LỢI NHUẬN ĐƠN HÀNG</td>
                                            </tr>
                                            <tr>
                                                <td>Giá Bán/Thùng</td>
                                                <td>Hoa Hồng</td>
                                                <td>Kê Giá</td>
                                                <td>Giá Bán/Bộ</td>
                                                <td>Doanh Thu Bán Hàng</td>
                                                <td>Giá Mua/m2</td>
                                                <td>Giá Bán Thực Tế/m2</td>
                                                <td>Lợi Nhuận Thực Tế</td>
                                                <td>Giá Vốn Bán Hàng</td>
                                                <td>Lợi Nhuận Bán Giấy</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="giá bán/thùng" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="giá bán/bộ" readonly /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="doanh thu" readonly /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="giá mua" readonly /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="giá bán thực tế" readonly /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="lợi Nhuận" readonly /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="giá vốn" readonly /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="lợi nhuận bán giấy" readonly /></td>
                                            </tr>
                                            <tr>
                                                <td>Phí Hao Hụt Giấy</td>
                                                <td>Phí Vận Chuyển</td>
                                                <td>Phí Bản IN</td>
                                                <td>Phí Khuôn Bế</td>
                                                <td>Hoa Hồng(%)</td>
                                                <td>Phí Tờ Khai</td>
                                                <td>Phí Gia Công</td>
                                                <td>Chi Phí Khác</td>
                                                <td colspan="2">Tổng Chi Phí</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td>
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" placeholder="" readonly /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">Lợi Nhuận Trước Thuế</td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">Phần Trăm Lợi Nhuận/Doanh Thu</td>
                                                <td colspan="2">
                                                    <input type="text" class="form-control" placeholder="" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan="10" class="header1">GHI CHÚ ĐƠN HÀNG</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Ghi Chú Đơn Hàng</td>
                                                <td colspan="8">
                                                    <textarea rows="3" class="form-control"></textarea></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Ghi Chú Sản Xuất</td>
                                                <td colspan="8">
                                                    <textarea rows="3" class="form-control"></textarea></td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">Ghi Chú Giao Hàng</td>
                                                <td colspan="8">
                                                    <textarea rows="3" class="form-control"></textarea></td>
                                            </tr>
                                        </tbody>
                                    </table>